$content = Get-Content 'd:\塔防刷刷刷\TaFangSSS\Assets\Scripts\Store\PlayerData.cs' -Raw -Encoding UTF8
$match = [regex]::Match($content, '大数名 = new\[\]\s*\{([^}]*)\}')
$body = $match.Groups[1].Value
$existing = @([regex]::Matches($body, '"([^"])"') | ForEach-Object { $_.Groups[1].Value })
$existingSet = [System.Collections.Generic.HashSet[string]]::new()
foreach ($c in $existing) { $existingSet.Add($c) | Out-Null }
Write-Host "existing=$($existing.Count) unique=$($existingSet.Count)"

$pool = Get-Content 'd:\塔防刷刷刷\pool.txt' -Raw -Encoding UTF8
$poolChars = $pool.ToCharArray() | Where-Object { $_ -ne "`n" -and $_ -ne " " -and $_ -ne "`r" }
$seen = [System.Collections.Generic.HashSet[string]]::new()
$chosen = New-Object System.Collections.Generic.List[string]
foreach ($c in $poolChars) {
    $cs = [string]$c
    if ($existingSet.Contains($cs)) { continue }
    if ($seen.Contains($cs)) { continue }
    $seen.Add($cs) | Out-Null
    $chosen.Add($cs)
    if ($chosen.Count -ge 500) { break }
}
Write-Host "chosen=$($chosen.Count)"

$bad = @()
foreach ($c in $chosen) { if ($existingSet.Contains($c)) { $bad += $c } }
Write-Host "overlap=$($bad.Count)"

$dq = [string][char]34
$groupSize = 12
$sb = New-Object System.Text.StringBuilder
$idx = 0
$startPower = 1004
$g = 0
while ($idx -lt $chosen.Count) {
    $g++
    $endIdx = [Math]::Min($idx + $groupSize - 1, $chosen.Count - 1)
    $group = $chosen[$idx..$endIdx]
    $endPower = $startPower + ($group.Count - 1) * 4
    $comment = "        // ---- 扩充" + $g + " : 10^" + $startPower + " ~ 10^" + $endPower + " ----"
    [void]$sb.AppendLine($comment)
    $parts = @()
    foreach ($c in $group) { $parts += ($dq + $c + $dq) }
    $line = '        ' + ($parts -join ', ') + ','
    [void]$sb.AppendLine($line)
    $idx += $groupSize
    $startPower = $endPower + 4
}
$sb.ToString() | Out-File 'd:\塔防刷刷刷\names_out.txt' -Encoding UTF8
Write-Host "done lastPower=$($startPower - 4)"
