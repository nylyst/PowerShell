Function Get-WindowsUpdate {
 
    [Cmdletbinding()]
    Param()
 
    Process {
        try {
            Write-Verbose "Getting Windows Update"
            $Session = New-Object -ComObject Microsoft.Update.Session            
            $Searcher = $Session.CreateUpdateSearcher()            
            $Criteria = "IsInstalled=0 and DeploymentAction='Installation' or IsPresent=1 and DeploymentAction='Uninstallation' or IsInstalled=1 and DeploymentAction='Installation' and RebootRequired=1 or IsInstalled=0 and DeploymentAction='Uninstallation' and RebootRequired=1"           
            $SearchResult = $Searcher.Search($Criteria)           
            $SearchResult.Updates
        } catch {
            Write-Warning -Message "Failed to query Windows Update because $($_.Exception.Message)"
        }
    }
}
 
Function Show-WindowsUpdate {
    Get-WindowsUpdate |
    Select Title,isHidden,
        @{l='Size (MB)';e={'{0:N2}' -f ($_.MaxDownloadSize/1MB)}},
        @{l='Published';e={$_.LastDeploymentChangeTime}} |
    Sort -Property Published
}


Function Set-WindowsHiddenUpdate {
 
    [Cmdletbinding()]
 
    Param(
        [Parameter(ValueFromPipeline=$true,Mandatory=$true)]
        [System.__ComObject[]]$Update,
 
        [Parameter(Mandatory=$true)]
        [boolean]$Hide
    )
 
    Process {
        $Update | ForEach-Object -Process {
            if (($_.pstypenames)[0] -eq 'System.__ComObject#{c1c2f21a-d2f4-4902-b5c6-8a081c19a890}') {
                try {
                    $_.isHidden = $Hide
                    Write-Verbose -Message "Dealing with update $($_.Title)"
                } catch {
                    Write-Warning -Message "Failed to perform action because $($_.Exception.Message)"
                }
            } else {
                Write-Warning -Message "Ignoring object submitted"
            }
        }
    }
}