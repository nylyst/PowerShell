<#
.SYNOPSIS
Retrieve password stored securely using SecureString objects

Author: Eric Walker

.PARAMETER Path
Optional.  Alternate path from which to load the users password.  If not specified, the password will be loaded from the users powershell profile directory.
#>

param(
	[Parameter(Mandatory=$false)][string] $Path
	)

Set-StrictMode -Version 2.0
$ErrorLog = 'LoadPassword-error.log'
######## START OF FUNCTION #######
function Load-Password {

$bytes = Get-Content securepassword.txt
$secure = ConvertTo-SecureString $bytes

# use "anything" as user name because we only care for the secret password
$cred = New-Object System.Management.Automation.PSCredential 'anything', $secure
$cred.GetNetworkCredential()

# example to launch an exe with a different users identity using the
# persisted pwd info:

# $pi = New-Object system.diagnostics.ProcessStartInfo
# $pi.FileName = "notepad.exe"
# $pi.Password = $cred.Password
# $pi.UserName = "Martina"
# $pi.LoadUserProfile = $false
# $pi.WorkingDirectory = "C:\users\public"
# $pi.Verb = "runas"
# $pi.UseShellExecute = $False
# 
# [System.Diagnostics.Process]::Start($pi)
}