& {
  Set-StrictMode -Off

  $commands = @{}
  
  # get all commands available
  foreach($command in (Get-Command -CommandType Function, Cmdlet))
  {
    # add each unique command to a hash table
    $name = $command.Name
    if ($commands.ContainsKey($name) -eq $false)
    {
      $commands.Add($name, $command)
    }
  }

  # get all commands found in script
  $items = [ISESteroids.SteroidsFixer.Helpers]::GetAST('Command')
  $SplattedItems = @()
	
  # examine each command found in script
  :outer foreach($item in $items)
  { 
    $namedparameters = @{}
    $positionalparameters = @{}
    
    # get command name...
    $CommandName = $item.CommandElements[0].Extent.Text
    
    # ...is it known?
    if ($commands.ContainsKey($CommandName))
    {
      # yes, check parameter definitions
      $Command = $commands[$CommandName]
      if ($Command.Parameters -ne $null)
      {
        # identify parameters used in the command
        $position = 0
        $elements = $item.CommandElements.Count -1
        for($i=1; $i -le $elements; $i++)
        {
          $element = $item.CommandElements[$i]
          # is it a non-splatted parameter?
          if ($element -is [System.Management.Automation.Language.CommandParameterAst])
          {
            # look up the parameter in the parameter definition
            $parameterName = $element.ParameterName
            $ParameterObject = $null
            if ($command.Parameters.ContainsKey($parameterName) -eq $false)
            {
              # not found, is it a dynamic parameter?
              $ParameterName = ($command.Parameters.Values | Where-Object { $_.isDynamic -eq $false } | Select-Object -ExpandProperty Name) -like "$ParameterName*"
              if ($command.Parameters.ContainsKey($parameterName) -eq $false)
              { continue outer }
            }
            # static parameter
            $ParameterObject = $Command.Parameters[$ParameterName]
            if ($ParameterObject.SwitchParameter -eq $false)
            {
              # no switch parameter
              $namedparameters.Add($ParameterName, $item.CommandElements[$i+1])
              $i++
            }
            else
            {
              # switch parameter
              $namedparameters.Add($parameterName, $null)
            }
          }
          else
          {
            # is it a splatted parameter?
            if ($item.CommandElements[$i] -is [System.Management.Automation.Language.VariableExpressionAst] -and $item.CommandElements[$i].Splatted )
            {
              $SplattedItems += $position
            }
            $positionalparameters.Add($position, $item.CommandElements[$i])
            $position++
						
          }
      
        }
      }
      # identify the correct parameterset
      $validSets = :setloop foreach($set in $Command.ParameterSets)
      {
        # all named parameters must be in
        foreach($par in $namedparameters.Keys)
        {
          if ($set.Parameters.Name -contains $par -eq $false)
          {
            continue setloop
          }
        }
        $set
      }
    
      if ($validSets.Count -eq 0) { continue outer }
    
      :parameterSets foreach($set in ($validSets | Sort-Object { $_.IsDefault } -Descending))
      {
        # find positional parameters
        $changes = @()
        $shift = 0
        foreach($parameter in ($set.Parameters | Sort-Object -Property Position))
        {
        
          $position = $parameter.Position
          if ($position -ge 0)
          {
            $name = $parameter.Name
            if ($namedparameters.ContainsKey($name)) 
            { 
              $shift-- 
            }
            else
            {
              $realposition = $position + $shift
              
              # if a paremeter takes values from remaining arguments, then do not turn it into a named parameter
              if ($positionalparameters.ContainsKey($realposition) -and ($parameter.ValueFromRemainingArguments -eq $false -or ($positionalparameters.Count -lt 2)))
              {
                # does the data type fit?
                $skip = $false
                if ($validSets.Count -eq 1)
                {
                  # one set remaining, do always
                }
                elseif ($positionalparameters[$realposition].GetType() -eq [System.Management.Automation.Language.ScriptBlockExpressionAst])
                {
                  if ($parameter.ParameterType -ne [ScriptBlock] -and $parameter.ParameterType -ne [ScriptBlock[]])
                  {
                    $changes = @()
                    continue parameterSets
                  }
                }
                elseif ($positionalparameters[$realposition].GetType() -eq [System.Management.Automation.Language.StringConstantExpressionAst])
                {
                  if ($parameter.ParameterType -ne [String] -and $parameter.ParameterType -ne [String[]] -and $parameter.ParameterType -ne [Object] -and $parameter.ParameterType -ne [Object[]])
                  {
                    $changes = @()
                    continue parameterSets
                  }
                }
                elseif ($positionalparameters[$realposition].GetType() -eq [System.Management.Automation.Language.ParenExpressionAst])
                {
                  if ($parameter.ParameterType -ne [Object] -and $parameter.ParameterType -ne [Object[]])
                  {
                    $changes = @()
                    continue parameterSets
                  }
                }
                elseif ($positionalparameters[$realposition].GetType() -eq [System.Management.Automation.Language.ArrayLiteralAst])
                {
                  if ($parameter.ParameterType -ne [Object] -and $parameter.ParameterType -ne [Object[]])
                  {
                    $changes = @()
                    continue parameterSets
                  }
                }
                elseif ($positionalparameters[$realposition].GetType() -eq [System.Management.Automation.Language.VariableExpressionAst])
                {
                  if ($parameter.ParameterType -ne $positionalparameters[$realposition].StaticType -and $parameter.ParameterType.GetElementType() -ne $positionalparameters[$realposition].StaticType)
                  {
                    $changes = @()
                    continue parameterSets
                  }
                }
                else
                {
                  $i = 1  
                }
                if ($skip -eq $false)
                {
                  if ($SplattedItems -notcontains $realposition)
                  {
                    $changes += 1
                    $padding = ' '
                    $statement = $positionalparameters[$realposition].Parent
                    $offset = $positionalparameters[$realposition].Extent.StartOffset - $statement.Extent.StartOffset
                    if ($statement.Extent.Text.SubString($offset-1, 1) -eq ' ')
                    {
                      $padding = ''
                    }
                    $changes[$changes.Count-1] = @($positionalparameters[$realposition].Extent.StartOffset, $positionalparameters[$realposition].Extent.StartOffset, ($padding + '-' + $parameter.Name + ' ')) 
                  }
                }
              }
            }
          
          }
        }
        foreach($change in $changes)
        {
          [ISESteroids.SteroidsFixer.Helpers]::AddTextChange($change[0], $change[1], $change[2])
        }
        break
      }
    
    
    }
  
  
  }
  Invoke-SteroidsTextChange
}
# SIG # Begin signature block
# MIId1AYJKoZIhvcNAQcCoIIdxTCCHcECAQExCzAJBgUrDgMCGgUAMGkGCisGAQQB
# gjcCAQSgWzBZMDQGCisGAQQBgjcCAR4wJgIDAQAABBAfzDtgWUsITrck0sYpfvNR
# AgEAAgEAAgEAAgEAAgEAMCEwCQYFKw4DAhoFAAQUL7efKU5ukU64SZsufRLlihgw
# zM6gghkGMIIFHDCCBASgAwIBAgIQAp+oNhrWxpP858ywp8f2ezANBgkqhkiG9w0B
# AQUFADBvMQswCQYDVQQGEwJVUzEVMBMGA1UEChMMRGlnaUNlcnQgSW5jMRkwFwYD
# VQQLExB3d3cuZGlnaWNlcnQuY29tMS4wLAYDVQQDEyVEaWdpQ2VydCBBc3N1cmVk
# IElEIENvZGUgU2lnbmluZyBDQS0xMB4XDTE0MDkwNDAwMDAwMFoXDTE1MDkwOTEy
# MDAwMFowcjELMAkGA1UEBhMCREUxFjAUBgNVBAgTDU5pZWRlcnNhY2hzZW4xETAP
# BgNVBAcTCEhhbm5vdmVyMRswGQYDVQQKExJUb2JpYXMgRHIuIFdlbHRuZXIxGzAZ
# BgNVBAMTElRvYmlhcyBEci4gV2VsdG5lcjCCASIwDQYJKoZIhvcNAQEBBQADggEP
# ADCCAQoCggEBAJUaFBmSOaJ2atB6X772tQWjbFYSUPeKkcQ6piLwrA2TS1I/175p
# R7UzgpPpuJ2/Gkqag/uZOS0SUwQm+Z6Y2TfkyzcyOJdO0kuwsl+/nJqVN97xIABt
# P3a3oVwxjo7BDmLFxMIPxint8bu5zy9LL2e3AUtH1ikTOrzo0qbJSJLorMlRZcgp
# dDg1gSloEUHeZBOBX3hgMQQFnk5lK6UeopqaxBd0S1BCYUEI2hJxJKerns0MmX9O
# ZppYz8giZo5Q7/bnRB73jT5YZjVQr2bnCuci1sz12KshwXvc6If+QqqKy6LsTWgh
# MD3n8J61+/+bbLuk8JzDlLciU07o1cNbdJ0CAwEAAaOCAa8wggGrMB8GA1UdIwQY
# MBaAFHtozimqwBe+SXrh5T/Wp/dFjzUyMB0GA1UdDgQWBBR8XU372FlNMblKRzWM
# 2+VbuGAYJDAOBgNVHQ8BAf8EBAMCB4AwEwYDVR0lBAwwCgYIKwYBBQUHAwMwbQYD
# VR0fBGYwZDAwoC6gLIYqaHR0cDovL2NybDMuZGlnaWNlcnQuY29tL2Fzc3VyZWQt
# Y3MtZzEuY3JsMDCgLqAshipodHRwOi8vY3JsNC5kaWdpY2VydC5jb20vYXNzdXJl
# ZC1jcy1nMS5jcmwwQgYDVR0gBDswOTA3BglghkgBhv1sAwEwKjAoBggrBgEFBQcC
# ARYcaHR0cHM6Ly93d3cuZGlnaWNlcnQuY29tL0NQUzCBggYIKwYBBQUHAQEEdjB0
# MCQGCCsGAQUFBzABhhhodHRwOi8vb2NzcC5kaWdpY2VydC5jb20wTAYIKwYBBQUH
# MAKGQGh0dHA6Ly9jYWNlcnRzLmRpZ2ljZXJ0LmNvbS9EaWdpQ2VydEFzc3VyZWRJ
# RENvZGVTaWduaW5nQ0EtMS5jcnQwDAYDVR0TAQH/BAIwADANBgkqhkiG9w0BAQUF
# AAOCAQEAgl6LemxL/XV0RqQqf32Yr1a0CM9vEjT0RUhBW+dCOlb6qIz7McSogSzk
# trrSmjNMjX5FzP/uTtDC38VGPV+iX1fENUWiYUBg7ZgxxGX25+uLxNltnTV69Xv8
# d+tfx6zBj8DOhet79v9GYJbBDmIoDdPOwC9fLFwrk0HeRs0Uc1bDCdU/6GJ9M7ho
# 9bDmcnsYaHrkwWyNzZvc2e0fpJD1e/KSRYHYT6Q15XAdn9neJewlBPoIAxgJsfHB
# Fo2pIYYTm7nRcY0zZEJUw8YMvt6XmnhTm88720vTy0pJM4T1KCMmgDdfgVC2jxWa
# RA3a/HWK+Srlku9b/W9qYuXLPVcPcDCCBmowggVSoAMCAQICEAMBmgI6/1ixa9bV
# 6uYX8GYwDQYJKoZIhvcNAQEFBQAwYjELMAkGA1UEBhMCVVMxFTATBgNVBAoTDERp
# Z2lDZXJ0IEluYzEZMBcGA1UECxMQd3d3LmRpZ2ljZXJ0LmNvbTEhMB8GA1UEAxMY
# RGlnaUNlcnQgQXNzdXJlZCBJRCBDQS0xMB4XDTE0MTAyMjAwMDAwMFoXDTI0MTAy
# MjAwMDAwMFowRzELMAkGA1UEBhMCVVMxETAPBgNVBAoTCERpZ2lDZXJ0MSUwIwYD
# VQQDExxEaWdpQ2VydCBUaW1lc3RhbXAgUmVzcG9uZGVyMIIBIjANBgkqhkiG9w0B
# AQEFAAOCAQ8AMIIBCgKCAQEAo2Rd/Hyz4II14OD2xirmSXU7zG7gU6mfH2RZ5nxr
# f2uMnVX4kuOe1VpjWwJJUNmDzm9m7t3LhelfpfnUh3SIRDsZyeX1kZ/GFDmsJOqo
# SyyRicxeKPRktlC39RKzc5YKZ6O+YZ+u8/0SeHUOplsU/UUjjoZEVX0YhgWMVYd5
# SEb3yg6Np95OX+Koti1ZAmGIYXIYaLm4fO7m5zQvMXeBMB+7NgGN7yfj95rwTDFk
# jePr+hmHqH7P7IwMNlt6wXq4eMfJBi5GEMiN6ARg27xzdPpO2P6qQPGyznBGg+na
# QKFZOtkVCVeZVjCT88lhzNAIzGvsYkKRrALA76TwiRGPdwIDAQABo4IDNTCCAzEw
# DgYDVR0PAQH/BAQDAgeAMAwGA1UdEwEB/wQCMAAwFgYDVR0lAQH/BAwwCgYIKwYB
# BQUHAwgwggG/BgNVHSAEggG2MIIBsjCCAaEGCWCGSAGG/WwHATCCAZIwKAYIKwYB
# BQUHAgEWHGh0dHBzOi8vd3d3LmRpZ2ljZXJ0LmNvbS9DUFMwggFkBggrBgEFBQcC
# AjCCAVYeggFSAEEAbgB5ACAAdQBzAGUAIABvAGYAIAB0AGgAaQBzACAAQwBlAHIA
# dABpAGYAaQBjAGEAdABlACAAYwBvAG4AcwB0AGkAdAB1AHQAZQBzACAAYQBjAGMA
# ZQBwAHQAYQBuAGMAZQAgAG8AZgAgAHQAaABlACAARABpAGcAaQBDAGUAcgB0ACAA
# QwBQAC8AQwBQAFMAIABhAG4AZAAgAHQAaABlACAAUgBlAGwAeQBpAG4AZwAgAFAA
# YQByAHQAeQAgAEEAZwByAGUAZQBtAGUAbgB0ACAAdwBoAGkAYwBoACAAbABpAG0A
# aQB0ACAAbABpAGEAYgBpAGwAaQB0AHkAIABhAG4AZAAgAGEAcgBlACAAaQBuAGMA
# bwByAHAAbwByAGEAdABlAGQAIABoAGUAcgBlAGkAbgAgAGIAeQAgAHIAZQBmAGUA
# cgBlAG4AYwBlAC4wCwYJYIZIAYb9bAMVMB8GA1UdIwQYMBaAFBUAEisTmLKZB+0e
# 36K+Vw0rZwLNMB0GA1UdDgQWBBRhWk0ktkkynUoqeRqDS/QeicHKfTB9BgNVHR8E
# djB0MDigNqA0hjJodHRwOi8vY3JsMy5kaWdpY2VydC5jb20vRGlnaUNlcnRBc3N1
# cmVkSURDQS0xLmNybDA4oDagNIYyaHR0cDovL2NybDQuZGlnaWNlcnQuY29tL0Rp
# Z2lDZXJ0QXNzdXJlZElEQ0EtMS5jcmwwdwYIKwYBBQUHAQEEazBpMCQGCCsGAQUF
# BzABhhhodHRwOi8vb2NzcC5kaWdpY2VydC5jb20wQQYIKwYBBQUHMAKGNWh0dHA6
# Ly9jYWNlcnRzLmRpZ2ljZXJ0LmNvbS9EaWdpQ2VydEFzc3VyZWRJRENBLTEuY3J0
# MA0GCSqGSIb3DQEBBQUAA4IBAQCdJX4bM02yJoFcm4bOIyAPgIfliP//sdRqLDHt
# OhcZcRfNqRu8WhY5AJ3jbITkWkD73gYBjDf6m7GdJH7+IKRXrVu3mrBgJuppVyFd
# NC8fcbCDlBkFazWQEKB7l8f2P+fiEUGmvWLZ8Cc9OB0obzpSCfDscGLTYkuw4HOm
# ksDTjjHYL+NtFxMG7uQDthSr849Dp3GdId0UyhVdkkHa+Q+B0Zl0DSbEDn8btfWg
# 8cZ3BigV6diT5VUW8LsKqxzbXEgnZsijiwoc5ZXarsQuWaBh3drzbaJh6YoLbewS
# GL33VVRAA5Ira8JRwgpIr7DUbuD0FAo6G+OPPcqvao173NhEMIIGozCCBYugAwIB
# AgIQD6hJBhXXAKC+IXb9xextvTANBgkqhkiG9w0BAQUFADBlMQswCQYDVQQGEwJV
# UzEVMBMGA1UEChMMRGlnaUNlcnQgSW5jMRkwFwYDVQQLExB3d3cuZGlnaWNlcnQu
# Y29tMSQwIgYDVQQDExtEaWdpQ2VydCBBc3N1cmVkIElEIFJvb3QgQ0EwHhcNMTEw
# MjExMTIwMDAwWhcNMjYwMjEwMTIwMDAwWjBvMQswCQYDVQQGEwJVUzEVMBMGA1UE
# ChMMRGlnaUNlcnQgSW5jMRkwFwYDVQQLExB3d3cuZGlnaWNlcnQuY29tMS4wLAYD
# VQQDEyVEaWdpQ2VydCBBc3N1cmVkIElEIENvZGUgU2lnbmluZyBDQS0xMIIBIjAN
# BgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnHz5oI8KyolLU5o87BkifwzL90hE
# 0D8ibppP+s7fxtMkkf+oUpPncvjxRoaUxasX9Hh/y3q+kCYcfFMv5YPnu2oFKMyg
# FxFLGCDzt73y3Mu4hkBFH0/5OZjTO+tvaaRcAS6xZummuNwG3q6NYv5EJ4KpA8P+
# 5iYLk0lx5ThtTv6AXGd3tdVvZmSUa7uISWjY0fR+IcHmxR7J4Ja4CZX5S56uzDG9
# alpCp8QFR31gK9mhXb37VpPvG/xy+d8+Mv3dKiwyRtpeY7zQuMtMEDX8UF+sQ0R8
# /oREULSMKj10DPR6i3JL4Fa1E7Zj6T9OSSPnBhbwJasB+ChB5sfUZDtdqwIDAQAB
# o4IDQzCCAz8wDgYDVR0PAQH/BAQDAgGGMBMGA1UdJQQMMAoGCCsGAQUFBwMDMIIB
# wwYDVR0gBIIBujCCAbYwggGyBghghkgBhv1sAzCCAaQwOgYIKwYBBQUHAgEWLmh0
# dHA6Ly93d3cuZGlnaWNlcnQuY29tL3NzbC1jcHMtcmVwb3NpdG9yeS5odG0wggFk
# BggrBgEFBQcCAjCCAVYeggFSAEEAbgB5ACAAdQBzAGUAIABvAGYAIAB0AGgAaQBz
# ACAAQwBlAHIAdABpAGYAaQBjAGEAdABlACAAYwBvAG4AcwB0AGkAdAB1AHQAZQBz
# ACAAYQBjAGMAZQBwAHQAYQBuAGMAZQAgAG8AZgAgAHQAaABlACAARABpAGcAaQBD
# AGUAcgB0ACAAQwBQAC8AQwBQAFMAIABhAG4AZAAgAHQAaABlACAAUgBlAGwAeQBp
# AG4AZwAgAFAAYQByAHQAeQAgAEEAZwByAGUAZQBtAGUAbgB0ACAAdwBoAGkAYwBo
# ACAAbABpAG0AaQB0ACAAbABpAGEAYgBpAGwAaQB0AHkAIABhAG4AZAAgAGEAcgBl
# ACAAaQBuAGMAbwByAHAAbwByAGEAdABlAGQAIABoAGUAcgBlAGkAbgAgAGIAeQAg
# AHIAZQBmAGUAcgBlAG4AYwBlAC4wEgYDVR0TAQH/BAgwBgEB/wIBADB5BggrBgEF
# BQcBAQRtMGswJAYIKwYBBQUHMAGGGGh0dHA6Ly9vY3NwLmRpZ2ljZXJ0LmNvbTBD
# BggrBgEFBQcwAoY3aHR0cDovL2NhY2VydHMuZGlnaWNlcnQuY29tL0RpZ2lDZXJ0
# QXNzdXJlZElEUm9vdENBLmNydDCBgQYDVR0fBHoweDA6oDigNoY0aHR0cDovL2Ny
# bDMuZGlnaWNlcnQuY29tL0RpZ2lDZXJ0QXNzdXJlZElEUm9vdENBLmNybDA6oDig
# NoY0aHR0cDovL2NybDQuZGlnaWNlcnQuY29tL0RpZ2lDZXJ0QXNzdXJlZElEUm9v
# dENBLmNybDAdBgNVHQ4EFgQUe2jOKarAF75JeuHlP9an90WPNTIwHwYDVR0jBBgw
# FoAUReuir/SSy4IxLVGLp6chnfNtyA8wDQYJKoZIhvcNAQEFBQADggEBAHtyHWT/
# iMg6wbfp56nEh7vblJLXkFkz+iuH3qhbgCU/E4+bgxt8Q8TmjN85PsMV7LDaOyEl
# eyTBcl24R5GBE0b6nD9qUTjetCXL8KvfxSgBVHkQRiTROA8moWGQTbq9KOY/8cSq
# m/baNVNPyfI902zcI+2qoE1nCfM6gD08+zZMkOd2pN3yOr9WNS+iTGXo4NTa0cfI
# kWotI083OxmUGNTVnBA81bEcGf+PyGubnviunJmWeNHNnFEVW0ImclqNCkojkkDo
# ht4iwpM61Jtopt8pfwa5PA69n8SGnIJHQnEyhgmZcgl5S51xafVB/385d2TxhI2+
# ix6yfWijpZCxDP8wggbNMIIFtaADAgECAhAG/fkDlgOt6gAK6z8nu7obMA0GCSqG
# SIb3DQEBBQUAMGUxCzAJBgNVBAYTAlVTMRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMx
# GTAXBgNVBAsTEHd3dy5kaWdpY2VydC5jb20xJDAiBgNVBAMTG0RpZ2lDZXJ0IEFz
# c3VyZWQgSUQgUm9vdCBDQTAeFw0wNjExMTAwMDAwMDBaFw0yMTExMTAwMDAwMDBa
# MGIxCzAJBgNVBAYTAlVTMRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsT
# EHd3dy5kaWdpY2VydC5jb20xITAfBgNVBAMTGERpZ2lDZXJ0IEFzc3VyZWQgSUQg
# Q0EtMTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAOiCLZn5ysJClaWA
# c0Bw0p5WVFypxNJBBo/JM/xNRZFcgZ/tLJz4FlnfnrUkFcKYubR3SdyJxArar8te
# a+2tsHEx6886QAxGTZPsi3o2CAOrDDT+GEmC/sfHMUiAfB6iD5IOUMnGh+s2P9gw
# w/+m9/uizW9zI/6sVgWQ8DIhFonGcIj5BZd9o8dD3QLoOz3tsUGj7T++25VIxO4e
# s/K8DCuZ0MZdEkKB4YNugnM/JksUkK5ZZgrEjb7SzgaurYRvSISbT0C58Uzyr5j7
# 9s5AXVz2qPEvr+yJIvJrGGWxwXOt1/HYzx4KdFxCuGh+t9V3CidWfA9ipD8yFGCV
# /QcEogkCAwEAAaOCA3owggN2MA4GA1UdDwEB/wQEAwIBhjA7BgNVHSUENDAyBggr
# BgEFBQcDAQYIKwYBBQUHAwIGCCsGAQUFBwMDBggrBgEFBQcDBAYIKwYBBQUHAwgw
# ggHSBgNVHSAEggHJMIIBxTCCAbQGCmCGSAGG/WwAAQQwggGkMDoGCCsGAQUFBwIB
# Fi5odHRwOi8vd3d3LmRpZ2ljZXJ0LmNvbS9zc2wtY3BzLXJlcG9zaXRvcnkuaHRt
# MIIBZAYIKwYBBQUHAgIwggFWHoIBUgBBAG4AeQAgAHUAcwBlACAAbwBmACAAdABo
# AGkAcwAgAEMAZQByAHQAaQBmAGkAYwBhAHQAZQAgAGMAbwBuAHMAdABpAHQAdQB0
# AGUAcwAgAGEAYwBjAGUAcAB0AGEAbgBjAGUAIABvAGYAIAB0AGgAZQAgAEQAaQBn
# AGkAQwBlAHIAdAAgAEMAUAAvAEMAUABTACAAYQBuAGQAIAB0AGgAZQAgAFIAZQBs
# AHkAaQBuAGcAIABQAGEAcgB0AHkAIABBAGcAcgBlAGUAbQBlAG4AdAAgAHcAaABp
# AGMAaAAgAGwAaQBtAGkAdAAgAGwAaQBhAGIAaQBsAGkAdAB5ACAAYQBuAGQAIABh
# AHIAZQAgAGkAbgBjAG8AcgBwAG8AcgBhAHQAZQBkACAAaABlAHIAZQBpAG4AIABi
# AHkAIAByAGUAZgBlAHIAZQBuAGMAZQAuMAsGCWCGSAGG/WwDFTASBgNVHRMBAf8E
# CDAGAQH/AgEAMHkGCCsGAQUFBwEBBG0wazAkBggrBgEFBQcwAYYYaHR0cDovL29j
# c3AuZGlnaWNlcnQuY29tMEMGCCsGAQUFBzAChjdodHRwOi8vY2FjZXJ0cy5kaWdp
# Y2VydC5jb20vRGlnaUNlcnRBc3N1cmVkSURSb290Q0EuY3J0MIGBBgNVHR8EejB4
# MDqgOKA2hjRodHRwOi8vY3JsMy5kaWdpY2VydC5jb20vRGlnaUNlcnRBc3N1cmVk
# SURSb290Q0EuY3JsMDqgOKA2hjRodHRwOi8vY3JsNC5kaWdpY2VydC5jb20vRGln
# aUNlcnRBc3N1cmVkSURSb290Q0EuY3JsMB0GA1UdDgQWBBQVABIrE5iymQftHt+i
# vlcNK2cCzTAfBgNVHSMEGDAWgBRF66Kv9JLLgjEtUYunpyGd823IDzANBgkqhkiG
# 9w0BAQUFAAOCAQEARlA+ybcoJKc4HbZbKa9Sz1LpMUerVlx71Q0LQbPv7HUfdDjy
# slxhopyVw1Dkgrkj0bo6hnKtOHisdV0XFzRyR4WUVtHruzaEd8wkpfMEGVWp5+Pn
# q2LN+4stkMLA0rWUvV5PsQXSDj0aqRRbpoYxYqioM+SbOafE9c4deHaUJXPkKqvP
# nHZL7V/CSxbkS3BMAIke/MV5vEwSV/5f4R68Al2o/vsHOE8Nxl2RuQ9nRc3Wg+3n
# kg2NsWmMT/tZ4CMP0qquAHzunEIOz5HXJ7cW7g/DvXwKoO4sCFWFIrjrGBpN/Coh
# rUkxg0eVd3HcsRtLSxwQnHcUwZ1PL1qVCCkQJjGCBDgwggQ0AgEBMIGDMG8xCzAJ
# BgNVBAYTAlVTMRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5k
# aWdpY2VydC5jb20xLjAsBgNVBAMTJURpZ2lDZXJ0IEFzc3VyZWQgSUQgQ29kZSBT
# aWduaW5nIENBLTECEAKfqDYa1saT/OfMsKfH9nswCQYFKw4DAhoFAKB4MBgGCisG
# AQQBgjcCAQwxCjAIoAKAAKECgAAwGQYJKoZIhvcNAQkDMQwGCisGAQQBgjcCAQQw
# HAYKKwYBBAGCNwIBCzEOMAwGCisGAQQBgjcCARUwIwYJKoZIhvcNAQkEMRYEFCP4
# BzxYapVGvyjHkWRATe3X0JztMA0GCSqGSIb3DQEBAQUABIIBAIJbTyWevtlN8yYT
# 3o0NhzTE9qVQDd+DQfzocD2qf/LuuM4IwZ0BYD+XDPGTNAvuw0BFCkBR5IKUcBiG
# zMmEn3UhzsqmhJGyHjnnGRy0izvF6qe72Wn+koJ7DM01CH4nB+6dq0kbZQa43s5X
# ftm0KTd8zwVdVwYiOeLbV0gj0XwUfQH2rSmba99PsIM78lxB0KuIahnfgNhKrwg3
# 0zZyprSqrUOhvSZ6JJ9oHH2qxCZe1lLnGBE91n0BY0DaEWpqsvfEkeGp3/j1pxo1
# mPIRyq31jFaDlaxKBq/6M2N6KqBVnrZpEHq1c59LT85v3ndVy4EFWKbCi69ivvIZ
# PzWHnSihggIPMIICCwYJKoZIhvcNAQkGMYIB/DCCAfgCAQEwdjBiMQswCQYDVQQG
# EwJVUzEVMBMGA1UEChMMRGlnaUNlcnQgSW5jMRkwFwYDVQQLExB3d3cuZGlnaWNl
# cnQuY29tMSEwHwYDVQQDExhEaWdpQ2VydCBBc3N1cmVkIElEIENBLTECEAMBmgI6
# /1ixa9bV6uYX8GYwCQYFKw4DAhoFAKBdMBgGCSqGSIb3DQEJAzELBgkqhkiG9w0B
# BwEwHAYJKoZIhvcNAQkFMQ8XDTE1MDUyOTA3NDMwOVowIwYJKoZIhvcNAQkEMRYE
# FMHWLNV0tMzTJkT99AJ8bZiPuH9lMA0GCSqGSIb3DQEBAQUABIIBAICJ2Hb4OrY5
# StDkQzkjeWkuuKTJqQb3JoonNG/VfdWVzjNuS7NqKHgwDsTa8P0+1cd2xtLKGJ/P
# 91AXm8Xpgui/V5olCKUGIDXTM7LOpVMDRpWQ9bXJ7XrKZVRzMgenVsHSe7k8lX8m
# Bv376uzTN/QbQEwjIB0e7O5Ezt9vqPqWZXmYOOIrqDpjPs48+FCAGsMB0uINOAQv
# 2seLVHmjASPEwPkqO/jdWS4ydKdQkjEqXXkCwMxnRrw/SyG3hfjkDrY8hWzJAdHz
# aXwJHClbCgM8ywAfqIMPLrEDOKWqmUMT4pLeeAa1SHhMPmnNlcvocD+DA7EZvja1
# utKurDH9M2I=
# SIG # End signature block
