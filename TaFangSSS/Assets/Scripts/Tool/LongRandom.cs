using System;

public static class LongRandom
{
    private static readonly Random _random = new Random();
    
    /// <summary>
    /// 获取 [min, max] 范围内的随机 long（包含最大值）
    /// </summary>
    public static long Range(long min, long max)
    {
        if (min > max)
            throw new ArgumentException("min 必须小于等于 max");
        
        if (min == max)
            return min;
        
        // 计算范围
        ulong range = (ulong)(max - min);
        
        // 如果范围小于 int.MaxValue，直接用 Random.Next()
        if (range <= int.MaxValue)
        {
            int randomInt = _random.Next((int)range + 1);
            return min + randomInt;
        }
        
        // 大范围：生成随机字节
        byte[] buffer = new byte[8];
        ulong result;
        
        do
        {
            _random.NextBytes(buffer);
            result = BitConverter.ToUInt64(buffer, 0);
        } 
        while (result > range); // 超出范围则重新生成
        
        return min + (long)result;
    }
}