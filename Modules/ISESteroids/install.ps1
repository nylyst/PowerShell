Write-Host -Object 'Installing ISESteroids'

$version = $PSVersionTable.PSVersion.Major

if ($version -lt 3)
{
  Write-Warning 'ISESteroids requires PowerShell 3 or better.'
  Write-Warning "Your current PowerShell version is $version."
  return
}

$isepath = Join-Path -Path $pshome -ChildPath 'powershell_ise.exe'
$iseExists = Test-Path -Path $isepath

if (!$iseExists)
{
  Write-Warning 'The built-in PowerShell ISE editor is not available on your system.'
  Write-Warning 'You may have to enable it in Windows Features first.'
}


$currentFolder = $PSScriptRoot

# running as script?
if ($currentFolder -eq '')
{
  Write-Warning -Message 'You need to run this code as a script. Make sure you opened the script from inside the unpacked ISESteroids ZIP folder!'
  return
}

# is in extracted zip folder?
$binaryExists = Test-Path -Path "$currentFolder\isesteroids.dll"
if (!$binaryExists)
{
  Write-Warning -Message 'Do not copy this script elsewhere! Run it from inside the extracted ZIP folder!'
  return
}

# unblock content of extracted zip folder
Get-ChildItem -Path $currentFolder -Recurse | Unblock-File

# copy module to user profile
$PSUserProfile = Split-Path $profile
$ModulesFolder = Join-Path -Path $PSUserProfile -ChildPath 'Modules'
$DestinationFolder = Join-Path -Path $ModulesFolder -ChildPath 'ISESteroids'

# create folder if not present
$exists = Test-Path -Path $DestinationFolder
if (!$exists)
{
  $null = New-Item -Path $DestinationFolder -Force -ItemType Directory
}

# current and destination folder identical?
if ($currentFolder -eq $DestinationFolder)
{
  Write-Host 'ISESteroids is installed already.' -ForegroundColor DarkYellow
  Write-Host 'Run "Start-Steroids" from inside the ISE editor to load ISESteroids.' -ForegroundColor DarkYellow
  return
}

Copy-Item -Path $currentFolder\* -Destination $DestinationFolder -Recurse -Force -ErrorVariable copyErrors -ErrorAction SilentlyContinue

if ($copyErrors.Count -gt 0)
{
  Write-Host 'There was a problem copying the module files onto your computer:' -ForegroundColor Yellow
  $copyErrors | ForEach-Object { Write-Host $_.Message -ForegroundColor Red }
  Write-Host 'Make sure you are not running another version of ISESteroids while installing.' -ForegroundColor Yellow
  Write-Host 'Run this script again once you solved the issue.'
}
else
{
  Write-Host -Object 'ISESteroids successfully installed.' -ForegroundColor Green
  Write-Host -Object 'To run, launch ISE editor:' -ForegroundColor Green
  Write-Host -Object ''
  Write-Host -Object 'ise'
  Write-Host -Object ''
  Write-Host -Object 'From inside the ISE editor, run:' -ForegroundColor Green
  Write-Host -Object ''
  Write-Host -Object 'Start-Steroids'
  Write-Host -Object ''
  Write-Host -Object ''
  Write-Host -Object 'Run "Start-Steroids" from INSIDE THE ISE EDITOR, not from here!' -ForegroundColor Green
  Write-Host -Object ''
  Write-Host -Object ''

 
}

