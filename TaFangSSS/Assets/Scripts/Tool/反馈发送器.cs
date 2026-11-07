using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// 玩家反馈发送器：通过飞书群自定义机器人 Webhook 把玩家输入的文本直接发到开发者群里。
/// 发送失败的内容会暂存到本地，下次启动时自动补发。
/// </summary>
public class 反馈发送器 : XSingleton<反馈发送器>
{
    // 飞书群 → 设置 → 群机器人 → 添加“自定义机器人”，复制得到的 Webhook 地址填在这里
    private const string Webhook地址 = "https://open.feishu.cn/open-apis/bot/v2/hook/5dc301d4-a128-4d18-9c2c-71279f4e687d";

    // 机器人安全设置里勾选了“签名校验”才需要填，未开启就留空
    private const string 签名密钥 = "";

    private const string 待发送Key = "玩家反馈_待发送";
    private const int 最大待发送条数 = 20;

    private static readonly List<string> 待发送缓存 = new List<string>();

    public static bool 已配置 => !string.IsNullOrEmpty(Webhook地址);

    protected override void Awake()
    {
        base.Awake();
        读取待发送();
        if (待发送缓存.Count > 0)
        {
            StartCoroutine(补发协程());
        }
    }

    /// <summary>
    /// 发送一条反馈，回调参数表示是否发送成功
    /// </summary>
    public void 发送(string 内容, Action<bool> 结果)
    {
        if (string.IsNullOrWhiteSpace(内容))
        {
            结果?.Invoke(false);
            return;
        }
        StartCoroutine(发送协程(内容, 结果, true));
    }

    private IEnumerator 发送协程(string 内容, Action<bool> 结果, bool 失败时暂存)
    {
        if (string.IsNullOrEmpty(Webhook地址))
        {
            结果?.Invoke(false);
            yield break;
        }

        using (var 请求 = new UnityWebRequest(Webhook地址, UnityWebRequest.kHttpVerbPOST))
        {
            请求.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(构造报文(内容)));
            请求.downloadHandler = new DownloadHandlerBuffer();
            请求.SetRequestHeader("Content-Type", "application/json");
            请求.timeout = 15;
            yield return 请求.SendWebRequest();

            bool 成功 = 请求.result == UnityWebRequest.Result.Success && 解析结果(请求.downloadHandler.text);
            if (!成功 && 失败时暂存)
            {
                加入待发送(内容);
            }
            结果?.Invoke(成功);
        }
    }

    private IEnumerator 补发协程()
    {
        string[] 快照 = 待发送缓存.ToArray();
        foreach (string 内容 in 快照)
        {
            bool 成功 = false;
            yield return 发送协程(内容, r => 成功 = r, false);
            if (成功)
            {
                待发送缓存.Remove(内容);
            }
        }
        保存待发送();
    }

    private static string 构造报文(string 内容)
    {
        var 报文 = new Dictionary<string, object>
        {
            { "msg_type", "text" },
            { "content", new Dictionary<string, string> { { "text", 内容 } } }
        };

        if (!string.IsNullOrEmpty(签名密钥))
        {
            long 时间戳 = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            报文["timestamp"] = 时间戳.ToString();
            报文["sign"] = 计算签名(时间戳);
        }

        return JsonConvert.SerializeObject(报文);
    }

    // 飞书签名规则：以“时间戳\n密钥”作为密钥，空内容做 HmacSHA256，再 Base64
    private static string 计算签名(long 时间戳)
    {
        string 待签 = 时间戳 + "\n" + 签名密钥;
        using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(待签)))
        {
            return Convert.ToBase64String(hmac.ComputeHash(new byte[0]));
        }
    }

    private static bool 解析结果(string 文本)
    {
        if (string.IsNullOrEmpty(文本))
        {
            return false;
        }

        try
        {
            var 数据 = JsonConvert.DeserializeObject<Dictionary<string, object>>(文本);
            if (数据 == null)
            {
                return false;
            }

            object 状态码;
            if (!数据.TryGetValue("code", out 状态码) && !数据.TryGetValue("StatusCode", out 状态码))
            {
                return false;
            }
            return Convert.ToInt32(状态码) == 0;
        }
        catch
        {
            return false;
        }
    }

    private static void 加入待发送(string 内容)
    {
        if (待发送缓存.Count >= 最大待发送条数)
        {
            待发送缓存.RemoveAt(0);
        }
        待发送缓存.Add(内容);
        保存待发送();
    }

    private static void 读取待发送()
    {
        待发送缓存.Clear();
        string 原始 = PlayerPrefs.GetString(待发送Key, "");
        if (string.IsNullOrEmpty(原始))
        {
            return;
        }

        try
        {
            var 列表 = JsonConvert.DeserializeObject<List<string>>(原始);
            if (列表 != null)
            {
                待发送缓存.AddRange(列表);
            }
        }
        catch
        {
        }
    }

    private static void 保存待发送()
    {
        PlayerPrefs.SetString(待发送Key, JsonConvert.SerializeObject(待发送缓存));
        PlayerPrefs.Save();
    }
}
