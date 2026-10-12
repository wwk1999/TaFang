$path = 'C:\Users\77070\AppData\LocalLow\DefaultCompany\TaFangSSS\TaFangStorePlaytest1.json'
$bytes = [System.IO.File]::ReadAllBytes($path)
Write-Host "Byte length: $($bytes.Length)"

# Try different encodings
$utf8 = [System.Text.Encoding]::UTF8.GetString($bytes)
Write-Host "UTF-8 char length: $($utf8.Length)"

# Try GBK / cp936 (common on Chinese Windows)
$gbk = [System.Text.Encoding]::GetEncoding('gb2312')
$gbkText = $gbk.GetString($bytes)
Write-Host "GB2312 char length: $($gbkText.Length)"

# Try default encoding
$default = [System.Text.Encoding]::Default.GetString($bytes)
Write-Host "Default encoding char length: $($default.Length)"
Write-Host "Default encoding name: $([System.Text.Encoding]::Default.EncodingName)"

# Try Unicode (UTF-16 LE)
$unicode = [System.Text.Encoding]::Unicode.GetString($bytes)
Write-Host "Unicode char length: $($unicode.Length)"

# The error position is 54589 - check which encoding matches
Write-Host ""
Write-Host "Error position: 54589"

# Let's also look at the GB2312 decoded text around position 54589
if ($gbkText.Length -gt 54589) {
    $pos = 54589
    $start = [Math]::Max(0, $pos - 100)
    $len = [Math]::Min(300, $gbkText.Length - $start)
    Write-Host ""
    Write-Host "GB2312 snippet around pos $pos:"
    Write-Host $gbkText.Substring($start, $len)
}
