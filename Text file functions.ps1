function Convert-ToWinText($UnixTextName, $WinTextName) {
    $UnixText = [System.IO.File]::ReadAllText($UnixTextName)
    $WinText = $UnixText.Replace("`n", "`r`n")
    [System.IO.File]::WriteAllText($WinTextName, $WinText)
}

function Convert-ToUnixText($WinTextName, $UnixTextName) {
    $WinText = [System.IO.File]::ReadAllText($WinTextName)
    $UnixText = $WinText.Replace("`n", "`r`n")
    [System.IO.File]::WriteAllText($UnixTextName, $UnixText)
}