$myWindowsID=[System.Security.Principal.WindowsIdentity]::GetCurrent()
$myWindowsPrincipal=new-object System.Security.Principal.WindowsPrincipal($myWindowsID)


$adminRole=[System.Security.Principal.WindowsBuiltInRole]::Administrator


if ($myWindowsPrincipal.IsInRole($adminRole)) {
    $Host.UI.RawUI.WindowTitle = $myInvocation.MyCommand.Definition + "(Elevated)"
    $Host.UI.RawUI.BackgroundColor = "Red"
} else {
   $newProcess = new-object System.Diagnostics.ProcessStartInfo "C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
   $newProcess.Arguments = $myInvocation.MyCommand.Definition;
   Write-Host $newProcess.Arguments;
   $newProcess.Verb = "runas";
   [System.Diagnostics.Process]::Start($newProcess);
}