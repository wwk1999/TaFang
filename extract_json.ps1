$path = 'C:\Users\77070\AppData\LocalLow\DefaultCompany\TaFangSSS\TaFangStorePlaytest1.json'
$bytes = [System.IO.File]::ReadAllBytes($path)

# Check for BOM
if ($bytes.Length -ge 3 -and $bytes[0] -eq 0xEF -and $bytes[1] -eq 0xBB -and $bytes[2] -eq 0xBF) {
    Write-Host "File has UTF-8 BOM"
    $text = [System.Text.Encoding]::UTF8.GetString($bytes, 3, $bytes.Length - 3)
} else {
    Write-Host "No BOM detected"
    $text = [System.Text.Encoding]::UTF8.GetString($bytes)
}
$charlen = $text.Length
Write-Host "Char length (without BOM): $charlen"

# Try to parse JSON using Newtonsoft from Unity's copy, or use .NET System.Text.Json
# Let's use a simpler approach - manually scan for the error
# The error says "Expected ':' but got: 1" after property name at path Player.PropListDic.洗练石
# Let's find the byte position that corresponds to char position 54589

# Actually, let's try to find where "1" appears right after a property name without ":"
# Search for pattern: "ChineseChars"1 (missing colon)
# Or more specifically, search for pattern where after a quoted string key, 
# instead of ": we get "1 or just 1

# Let me search for all places in the file where a quote is followed by a digit 
# instead of colon - pattern: " followed by digit (0-9) not preceded by :
# This would indicate a missing colon
Write-Host "=== Searching for missing colons (quote followed by digit) ==="
$quote = [byte]0x22  # "
$colon = [byte]0x3A  # :
$count = 0
for ($i = 1; $i -lt $bytes.Length - 1; $i++) {
    if ($bytes[$i] -ge 0x30 -and $bytes[$i] -le 0x39) {
        # Current byte is a digit
        if ($bytes[$i-1] -eq $quote) {
            # Previous byte was a quote - could be "1... 
            # Check if the quote before that is a key-ending quote or value-starting quote
            # If the byte before the quote is NOT a colon or comma or { or [, then it's a key-ending quote
            # and we're missing a colon
            if ($i -ge 2 -and $bytes[$i-2] -ne $colon -and $bytes[$i-2] -ne 0x2C -and $bytes[$i-2] -ne 0x7B -and $bytes[$i-2] -ne 0x5B) {
                # This might be a missing colon
                $s = [Math]::Max(0, $i - 60)
                $l = [Math]::Min(120, $bytes.Length - $s)
                $snip = [System.Text.Encoding]::UTF8.GetString($bytes, $s, $l)
                Write-Host "Possible missing colon at byte $i"
                Write-Host "  Snippet: $snip"
                $count++
            }
        }
    }
}
Write-Host "Total possible missing colons: $count"
