New-Task -MultipleInstancePolicy Parallel | 
    Add-TaskAction -Script { 
        Get-Process | Out-GridView 
        Start-Sleep -Seconds 75
    } |
    Add-TaskTrigger -In (New-TimeSpan -Seconds 15) -Repeat (New-TimeSpan -Minutes 1) -For (New-TimeSpan -Minutes 2) |
    Register-ScheduledTask -name (Get-Random)
