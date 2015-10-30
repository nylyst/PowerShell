#
# SimplySql.psm1
#

New-Alias -Name "osc" -Value Open-SqlConnection
New-Alias -Name "ssc" -Value Show-SqlConnection
New-Alias -Name "csc" -Value Close-SqlConnection
New-Alias -Name "isq" -Value Invoke-SqlQuery
New-Alias -Name "isu" -Value Invoke-SqlUpdate
New-Alias -Name "iss" -Value Invoke-SqlScalar
New-Alias -Name "tsc" -Value Test-SqlConnection

Export-ModuleMember -Alias * -Cmdlet *
