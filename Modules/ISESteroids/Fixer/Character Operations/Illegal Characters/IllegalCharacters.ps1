# Replaces individual ASCII and UNICODE characters

# use this to change illegal characters
# illegal characters may be introduced when scripts are copied from
# web pages or text editors, and typographic changes were made

& {
  # get access to the editor:
  $Editor = Get-SteroidsEditor
  
  # get script content:
  $text = $Editor.Text
  
  # this table controls character replacements
  # the KEY is the hexadecimal value of the character to replace
  # four-digit numbers represent UNICODE characters
  # the VALUE is the character that is used as replacement
  $replacementTable = @{
    
    # UNICODE characters to replace:
    '2013' = '-'
    '2014' = '-'
    '2015' = '-'
    '201C' = '"'
    '201D' = '"'
    '201E' = '"'
    '2018' = "'"
    '2019' = "'"
    '201A' = "'"
    '201B' = "'"
    '2033' = '"'
    '00BB' = '"'
    '02BA' = '"'
    '02BB' = "'"
    '02BC' = "'"
    '02BD' = "'"
    '02DD' = '"'
    '02EE' = '"'
    '02F5' = '"'
    '02F6' = '"'
    '030B' = '"'
    '030F' = '"'
    '0312' = "'"
    '0313' = "'"
    '0314' = "'"
    '0315' = "'"
    
    # ASCII Codes to replace:
    '0001' = ''
    '0002' = ''
    '0003' = ''
    '0004' = ''
    '0005' = ''
    '0006' = ''
    '0007' = ''
    '0008' = ''
    '000B' = ''
    '000C' = ''
    '000E' = ''
    '000F' = ''
  }
  
  # loop through the characters that need replacements
  foreach($UnicodeChar in $replacementTable.Keys)
  {
    # find the instances using a regular expression
    # the return value is always a pair of two:
    # - a MatchCollection returned by Match()
    # - and a string containing the desired replacement character
    
    [Regex]::Matches($text, "\u$UnicodeChar") | Add-SteroidsTextChange -ReplacementText $replacementTable[$UnicodeChar]
  }
  
  # finalize all changes:
  Invoke-SteroidsTextChange  
}


# SIG # Begin signature block
# MIIOggYJKoZIhvcNAQcCoIIOczCCDm8CAQExCzAJBgUrDgMCGgUAMGkGCisGAQQB
# gjcCAQSgWzBZMDQGCisGAQQBgjcCAR4wJgIDAQAABBAfzDtgWUsITrck0sYpfvNR
# AgEAAgEAAgEAAgEAAgEAMCEwCQYFKw4DAhoFAAQUTQXKIszS78oCyyDMWVBld/z7
# JuigggvHMIIFHDCCBASgAwIBAgIQAp+oNhrWxpP858ywp8f2ezANBgkqhkiG9w0B
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
# RA3a/HWK+Srlku9b/W9qYuXLPVcPcDCCBqMwggWLoAMCAQICEA+oSQYV1wCgviF2
# /cXsbb0wDQYJKoZIhvcNAQEFBQAwZTELMAkGA1UEBhMCVVMxFTATBgNVBAoTDERp
# Z2lDZXJ0IEluYzEZMBcGA1UECxMQd3d3LmRpZ2ljZXJ0LmNvbTEkMCIGA1UEAxMb
# RGlnaUNlcnQgQXNzdXJlZCBJRCBSb290IENBMB4XDTExMDIxMTEyMDAwMFoXDTI2
# MDIxMDEyMDAwMFowbzELMAkGA1UEBhMCVVMxFTATBgNVBAoTDERpZ2lDZXJ0IElu
# YzEZMBcGA1UECxMQd3d3LmRpZ2ljZXJ0LmNvbTEuMCwGA1UEAxMlRGlnaUNlcnQg
# QXNzdXJlZCBJRCBDb2RlIFNpZ25pbmcgQ0EtMTCCASIwDQYJKoZIhvcNAQEBBQAD
# ggEPADCCAQoCggEBAJx8+aCPCsqJS1OaPOwZIn8My/dIRNA/Im6aT/rO38bTJJH/
# qFKT53L48UaGlMWrF/R4f8t6vpAmHHxTL+WD57tqBSjMoBcRSxgg87e98tzLuIZA
# RR9P+TmY0zvrb2mkXAEusWbpprjcBt6ujWL+RCeCqQPD/uYmC5NJceU4bU7+gFxn
# d7XVb2ZklGu7iElo2NH0fiHB5sUeyeCWuAmV+UuerswxvWpaQqfEBUd9YCvZoV29
# +1aT7xv8cvnfPjL93SosMkbaXmO80LjLTBA1/FBfrENEfP6ERFC0jCo9dAz0eoty
# S+BWtRO2Y+k/Tkkj5wYW8CWrAfgoQebH1GQ7XasCAwEAAaOCA0MwggM/MA4GA1Ud
# DwEB/wQEAwIBhjATBgNVHSUEDDAKBggrBgEFBQcDAzCCAcMGA1UdIASCAbowggG2
# MIIBsgYIYIZIAYb9bAMwggGkMDoGCCsGAQUFBwIBFi5odHRwOi8vd3d3LmRpZ2lj
# ZXJ0LmNvbS9zc2wtY3BzLXJlcG9zaXRvcnkuaHRtMIIBZAYIKwYBBQUHAgIwggFW
# HoIBUgBBAG4AeQAgAHUAcwBlACAAbwBmACAAdABoAGkAcwAgAEMAZQByAHQAaQBm
# AGkAYwBhAHQAZQAgAGMAbwBuAHMAdABpAHQAdQB0AGUAcwAgAGEAYwBjAGUAcAB0
# AGEAbgBjAGUAIABvAGYAIAB0AGgAZQAgAEQAaQBnAGkAQwBlAHIAdAAgAEMAUAAv
# AEMAUABTACAAYQBuAGQAIAB0AGgAZQAgAFIAZQBsAHkAaQBuAGcAIABQAGEAcgB0
# AHkAIABBAGcAcgBlAGUAbQBlAG4AdAAgAHcAaABpAGMAaAAgAGwAaQBtAGkAdAAg
# AGwAaQBhAGIAaQBsAGkAdAB5ACAAYQBuAGQAIABhAHIAZQAgAGkAbgBjAG8AcgBw
# AG8AcgBhAHQAZQBkACAAaABlAHIAZQBpAG4AIABiAHkAIAByAGUAZgBlAHIAZQBu
# AGMAZQAuMBIGA1UdEwEB/wQIMAYBAf8CAQAweQYIKwYBBQUHAQEEbTBrMCQGCCsG
# AQUFBzABhhhodHRwOi8vb2NzcC5kaWdpY2VydC5jb20wQwYIKwYBBQUHMAKGN2h0
# dHA6Ly9jYWNlcnRzLmRpZ2ljZXJ0LmNvbS9EaWdpQ2VydEFzc3VyZWRJRFJvb3RD
# QS5jcnQwgYEGA1UdHwR6MHgwOqA4oDaGNGh0dHA6Ly9jcmwzLmRpZ2ljZXJ0LmNv
# bS9EaWdpQ2VydEFzc3VyZWRJRFJvb3RDQS5jcmwwOqA4oDaGNGh0dHA6Ly9jcmw0
# LmRpZ2ljZXJ0LmNvbS9EaWdpQ2VydEFzc3VyZWRJRFJvb3RDQS5jcmwwHQYDVR0O
# BBYEFHtozimqwBe+SXrh5T/Wp/dFjzUyMB8GA1UdIwQYMBaAFEXroq/0ksuCMS1R
# i6enIZ3zbcgPMA0GCSqGSIb3DQEBBQUAA4IBAQB7ch1k/4jIOsG36eepxIe725SS
# 15BZM/orh96oW4AlPxOPm4MbfEPE5ozfOT7DFeyw2jshJXskwXJduEeRgRNG+pw/
# alE43rQly/Cr38UoAVR5EEYk0TgPJqFhkE26vSjmP/HEqpv22jVTT8nyPdNs3CPt
# qqBNZwnzOoA9PPs2TJDndqTd8jq/VjUvokxl6ODU2tHHyJFqLSNPNzsZlBjU1ZwQ
# PNWxHBn/j8hrm574rpyZlnjRzZxRFVtCJnJajQpKI5JA6IbeIsKTOtSbaKbfKX8G
# uTwOvZ/EhpyCR0JxMoYJmXIJeUudcWn1Qf9/OXdk8YSNvosesn1oo6WQsQz/MYIC
# JTCCAiECAQEwgYMwbzELMAkGA1UEBhMCVVMxFTATBgNVBAoTDERpZ2lDZXJ0IElu
# YzEZMBcGA1UECxMQd3d3LmRpZ2ljZXJ0LmNvbTEuMCwGA1UEAxMlRGlnaUNlcnQg
# QXNzdXJlZCBJRCBDb2RlIFNpZ25pbmcgQ0EtMQIQAp+oNhrWxpP858ywp8f2ezAJ
# BgUrDgMCGgUAoHgwGAYKKwYBBAGCNwIBDDEKMAigAoAAoQKAADAZBgkqhkiG9w0B
# CQMxDAYKKwYBBAGCNwIBBDAcBgorBgEEAYI3AgELMQ4wDAYKKwYBBAGCNwIBFTAj
# BgkqhkiG9w0BCQQxFgQU8IcwmzWPuqW1kzKvbofQAtVcYW4wDQYJKoZIhvcNAQEB
# BQAEggEAHqG2xwjxUz6U1wlTu4nqzjxt7khibmTzgkQbc9vIBGBwKgmk8PbRE3fb
# vc7iaRLHYudaqrhzmuJ0K8jvjDss0qRZVs3DpEAEsXOxzrAIDr3HK73QItq3gpFR
# LC+z8g5PE+xiQ42uhfmYYArX2c6KBnpWi8BoBmvBSCKXAGzy/jqE4xa35MAp1l4K
# 1TnfFsOvTrCWJuxBhz9v3pb6NPs4fUep1Av3OuJhFI2jKUyE42g3GQORoyulKEsy
# LJwjRw9sMRri2+IoKHHmhmy+FY26RK2WMBfcs4aC1F+EA8FpQsl/D2xuTNZjdJnD
# WwZUrLwES0nbhGSwcNRdWiRoxNNPBA==
# SIG # End signature block
