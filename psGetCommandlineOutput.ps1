$p = New-Object System.Diagnostics.Process
$p.StartInfo = New-Object System.Diagnostics.ProcessStartInfo;
$p.StartInfo.FileName = "c:\windows\system32\runas.exe"
#$p.StartInfo.Arguments = "/trustlevel:0x20000 C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\devenv.exe"
#$p.StartInfo.CreateNoWindow = $true
#$p.StartInfo.RedirectStandardError = $true
$p.StartInfo.RedirectStandardOutput = $true
$p.StartInfo.UseShellExecute = $false
$p.Start()
$stdout = $p.StandardOutput.ReadToEnd()
#$stderr = $p.StandardError.ReadToEnd()
$p.WaitForExit()
$code = $p.ExitCode

Write-Host 'ExitCode=' + $code

write-host 'stdout=' + $stdout
