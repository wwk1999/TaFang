Add-Type -AssemblyPath 'C:\Program Files\Unity\Hub\Editor\2022.3.22f1\Editor\Data\Managed\Newtonsoft.Json.dll'

$path = 'C:\Users\77070\AppData\LocalLow\DefaultCompany\TaFangSSS\TaFangStorePlaytest1.json'
$json = [System.IO.File]::ReadAllText($path, [System.Text.Encoding]::UTF8)
Write-Host "String length: $($json.Length)"

# Try to parse and catch error
try {
    $obj = [Newtonsoft.Json.JsonConvert]::DeserializeObject($json)
    Write-Host "JSON parsed successfully"
} catch {
    Write-Host "JSON parse error: $($_.Exception.Message)"
    
    # Get the JsonReaderException specific details
    if ($_ -is [Newtonsoft.Json.JsonReaderException]) {
        $jre = [Newtonsoft.Json.JsonReaderException]$_
        Write-Host "Line: $($jre.LineNumber), Position: $($jre.LinePosition)"
        Write-Host "Path: $($jre.Path)"
        
        # Show context around the error position
        $pos = $jre.LinePosition - 1
        $start = [Math]::Max(0, $pos - 100)
        $len = [Math]::Min(300, $json.Length - $start)
        Write-Host "Context around error (char pos $pos):"
        Write-Host $json.Substring($start, $len)
    }
}
