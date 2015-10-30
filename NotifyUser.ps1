param 
( 
    $msg = "For the latest updates check our intranet website. Please click in the balloon.", 
    $title = "News", 
    $icon = "None", 
    $timeout=1 
) 
 
[System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms") | out-null 
[System.Reflection.Assembly]::LoadWithPartialName("System.Drawing") | out-null 
 
$Balloon = new-object System.Windows.Forms.NotifyIcon  
$Balloon.Icon = [System.Drawing.SystemIcons]::Information 
$Balloon.Visible = $true; 
$Balloon.ShowBalloonTip($timeout, $title, $msg, $icon); 
 
Unregister-Event -SourceIdentifier click_event -ErrorAction SilentlyContinue 
Register-ObjectEvent $Balloon BalloonTipClicked -sourceIdentifier click_event -Action { 
 
$ie = New-Object -com InternetExplorer.Application 
$ie.navigate2("https://intranet.mydomain.com") 
$ie.visible = $true 
 
} | Out-Null 
 
Wait-Event -timeout 15 -sourceIdentifier click_event > $null 
Remove-Event click_event -ea SilentlyContinue 
Unregister-Event -SourceIdentifier click_event -ErrorAction SilentlyContinue 
$Balloon.Dispose() 