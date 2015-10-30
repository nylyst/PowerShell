@Echo off 
SET INST=%~dp0
powershell.exe -noprofile -noexit -executionpolicy bypass -file "%INST%install.ps1"
 
