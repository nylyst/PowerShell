#
# Connect-RDP.ps1
#
# Written by Aaron Wurthmann (aaron (AT) wurthmann (DOT) com)
#
# If you edit please keep my name as an original author and
# keep me apprised of the changes, see email address above.
# This code may not be used for commercial purposes.
# You the executor, runner, user accept all liability.
# This code comes with ABSOLUTELY NO WARRANTY.
# You may redistribute copies of the code under the terms of the GPL v2.
# -----------------------------------------------------------------------
# 2011.03.18 ver 3.0
#
# Summary:
# Reconnect to systems after they’ve been rebooted. 
# Replaces the age old “Ping till you get a reply” method and plays the
# Super Mario Brothers theme while you wait.
#
# Current version has limited error and syntax checking.
# -----------------------------------------------------------------------
# Usage: Connect-RDP.ps1 <host or IP address>
# 
# -----------------------------------------------------------------------
# Notes:
# This script started out as a replacement for my rdp.cmd script that 
# used the “Ping till you get a reply” method then waited two minutes and 
# connected via Remote Desktop. Then I learned how to make sounds in PowerShell.
# -----------------------------------------------------------------------



Param([string]$strhost="127.0.0.1",$limit=1,$total=18)

function Get-IP {
    $IPAddress=$null
    $chkresult=[System.Net.IPAddress]::tryparse($strhost,[ref]$IPAddress) -and $strhost -eq $IPaddress.tostring()
    if ($chkresult -eq $false){
    $strhost=Get-Lookup
    }
}

function Get-Lookup{
    [string]$lookup=nslookup $strhost | Select-String "Name"
    if (!$lookup){
        write-host 'ERROR:' $strhost 'not found'
        exit
    }
    $result=$lookup.Split(" ")
    if($result){
        return $result[-1]
    }
    Else{
        write-host 'ERROR:' $strhost 'not found'
        exit
    }
}

function Test-Port{
    Param([string]$srv=$strhost,$port=3389,$timeout=300)    
    $ErrorActionPreference = "SilentlyContinue"
    $tcpclient = new-Object system.Net.Sockets.TcpClient
    $iar = $tcpclient.BeginConnect($srv,$port,$null,$null)
    $wait = $iar.AsyncWaitHandle.WaitOne($timeout,$false)
    if(!$wait)
    {
        $tcpclient.Close()
        Return $false
    }
    else
    {
        $error.Clear()
        $tcpclient.EndConnect($iar) | out-Null
        Return $true
        $tcpclient.Close()
    }
}

function Play-MarioInto {
    [console]::beep($E, $SIXTEENTH)
    [console]::beep($E, $EIGHTH)
    [console]::beep($E, $SIXTEENTH)
    Start-Sleep -m $SIXTEENTH
    [console]::beep($C, $SIXTEENTH)
    [console]::beep($E, $EIGHTH)
    [console]::beep($G, $QUARTER)
}

function Play-Mario1-1 {
    [console]::beep($C, $EIGHTHDOT)
    [console]::beep($GbelowC, $SIXTEENTH)
    Start-Sleep -m $EIGHTH
    [console]::beep($EbelowG, $SIXTEENTH)
    Start-Sleep -m $SIXTEENTH
    [console]::beep($A, $EIGHTH)
    [console]::beep($B, $SIXTEENTH)
    Start-Sleep -m $SIXTEENTH
    [console]::beep($Asharp, $SIXTEENTH)
    [console]::beep($A, $EIGHTH)
    [console]::beep($GbelowC, $SIXTEENTHDOT)
    [console]::beep($E, $SIXTEENTHDOT)
    [console]::beep($G, $EIGHTH)
    [console]::beep($AHigh, $EIGHTH)
    [console]::beep($F, $SIXTEENTH)
    [console]::beep($G, $SIXTEENTH)
    Start-Sleep -m $SIXTEENTH
    [console]::beep($E, $EIGHTH)
    [console]::beep($C, $SIXTEENTH)
    [console]::beep($D, $SIXTEENTH)
    [console]::beep($B, $EIGHTHDOT)
    [console]::beep($C, $EIGHTHDOT)
    [console]::beep($GbelowC, $SIXTEENTH)
    Start-Sleep -m $EIGHTH
    [console]::beep($EbelowG, $EIGHTH)
    Start-Sleep -m $SIXTEENTH
    [console]::beep($A, $EIGHTH)
    [console]::beep($B, $SIXTEENTH)
    Start-Sleep -m $SIXTEENTH
    [console]::beep($Asharp, $SIXTEENTH)
    [console]::beep($A, $EIGHTH)
    [console]::beep($GbelowC, $SIXTEENTHDOT)
    [console]::beep($E, $SIXTEENTHDOT)
    [console]::beep($G, $EIGHTH)
    [console]::beep($AHigh, $EIGHTH)
    [console]::beep($F, $SIXTEENTH)
    [console]::beep($G, $SIXTEENTH)
    Start-Sleep -m $SIXTEENTH
    [console]::beep($E, $EIGHTH)
    [console]::beep($C, $SIXTEENTH)
    [console]::beep($D, $SIXTEENTH)
    [console]::beep($B, $EIGHTHDOT)
    Start-Sleep -m $EIGHTH
    [console]::beep($G, $SIXTEENTH)
    [console]::beep($Fsharp, $SIXTEENTH)
    [console]::beep($F, $SIXTEENTH)
    [console]::beep($Dsharp, $EIGHTH)
    [console]::beep($E, $SIXTEENTH)
    Start-Sleep -m $SIXTEENTH
    [console]::beep($GbelowCSharp, $SIXTEENTH)
    [console]::beep($A, $SIXTEENTH)
    [console]::beep($C, $SIXTEENTH)
    Start-Sleep -m $SIXTEENTH
    [console]::beep($A, $SIXTEENTH)
    [console]::beep($C, $SIXTEENTH)
    [console]::beep($D, $SIXTEENTH)
    Start-Sleep -m $EIGHTH
    [console]::beep($G, $SIXTEENTH)
    [console]::beep($Fsharp, $SIXTEENTH)
    [console]::beep($F, $SIXTEENTH)
    [console]::beep($Dsharp, $EIGHTH)
    [console]::beep($E, $SIXTEENTH)
    Start-Sleep -m $SIXTEENTH
    [console]::beep($CHigh, $EIGHTH)
    [console]::beep($CHigh, $SIXTEENTH)
    [console]::beep($CHigh, $QUARTER)
    [console]::beep($G, $SIXTEENTH)
    [console]::beep($Fsharp, $SIXTEENTH)
    [console]::beep($F, $SIXTEENTH)
    [console]::beep($Dsharp, $EIGHTH)
    [console]::beep($E, $SIXTEENTH)
    Start-Sleep -m $SIXTEENTH
    [console]::beep($GbelowCSharp, $SIXTEENTH)
    [console]::beep($A, $SIXTEENTH)
    [console]::beep($C, $SIXTEENTH)
    Start-Sleep -m $SIXTEENTH
    [console]::beep($A, $SIXTEENTH)
    [console]::beep($C, $SIXTEENTH)
    [console]::beep($D, $SIXTEENTH)
    Start-Sleep -m $EIGHTH
    [console]::beep($Dsharp, $EIGHTH)
    Start-Sleep -m $SIXTEENTH
    [console]::beep($D, $EIGHTH)
    [console]::beep($C, $QUARTER)
}

#Set Speed and Tones
if($CHigh -eq $null) {
    $WHOLE = 2200
    $HALF = $WHOLE / 2
    $QUARTER = $HALF / 2
    $EIGHTH = $QUARTER / 2
    $SIXTEENTH = $EIGHTH / 2
    $EIGHTHDOT = $EIGHTH + $SIXTEENTH
    $QUARTERDOT = $QUARTER + $EIGHTH
    $SIXTEENTHDOT = $SIXTEENTH + ($SIXTEENTH / 2)


    $REST = 37
    $EbelowG = 164
    $GbelowC = 196
    $GbelowCSharp = 207
    $A = 220
    $Asharp = 233
    $B = 247
    $C = 262
    $Csharp = 277
    $D = 294
    $Dsharp = 311
    $E = 330
    $F = 349
    $Fsharp = 370
    $G = 392
    $Gsharp = 415
    $AHigh = 440
    $CHigh = 523
}


# Check to see if entry is a valid IPv4 address. 
#    If not treat as a host.
#        if host, do an nslookup before attemting connect.
#            If fail throw error.
Clear-Host
Get-IP
Play-MarioInto

$SecondsTotal = $total * 17

#write-host "Testing:" $strhost

while ($totalCt -lt $total) {
    $totalCt++
    $SecondsCt = $totalct * 17
    $SecondsRemaining = $SecondsTotal - $SecondsCt
    $PercentComplete = $SecondsCt / $SecondsTotal * 100
    $PercentLeft = 100 - $PercentComplete
    Write-Progress -Activity "Checking RDP on $strhost..." -PercentComplete $PercentLeft -currentOperation "Checking status of tcp port 3389 on $strhost" -SecondsRemaining $SecondsRemaining -Status "Will give up after 00:05:00"
    #write-host "Total Count:" $totalct
    $count=0
    [string]$strresult=Test-Port
    while ($strresult -eq $true) {
        $count++
        Write-Progress -Activity "Checking RDP on $strhost..." -Completed -Status "Has answered."
        #write-host "Answer Count:" $count
        $SecondsLimit = $limit * 10
        $SecondsCt = $count * 10
        $SecondsRemaining = $SecondsLimit - $SecondsCt
        $PercentComplete = $SecondsCt / $SecondsLimit * 100
        Write-Progress -Activity "$strhost is ready for RDP" -PercentComplete $PercentComplete -currentOperation "$strhost has replied" -SecondsRemaining $SecondsRemaining -Status "Will connect after $SecondsLimit seconds"
        [string]$strresult=Test-Port
        if ($count -ge $limit) {
            Write-Progress -Activity "$strhost is ready for RDP" -Completed -Status "Connecting..."
            mstsc.exe /v:$strHost
            exit
        }
    Start-Sleep -s 9
    }
Play-Mario1-1
}