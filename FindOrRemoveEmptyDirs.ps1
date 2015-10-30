<#
.SYNOPSIS
Svendsen Tech's generic script for removing empty directories from a
directory tree structure.

Finds or removes/deletes empty directories recursively from the drive or
directory you specify.

You will need to use the -VerifyNoEmpty parameter or multiple
runs to get rid of nested empty directories. See the -VerifyNoEmpty parameter's
description for further details.

This isn't the most efficient approach as the ones I can think of seem to
increase the script's complexity considerably. It should be useful for a
multitude of use cases.

Author: Joakim Svendsen

.PARAMETER Path
Required. Base root path to iterate recursively.
.PARAMETER Find
Default behaviour where it just prints. Overrides -Remove if both are specified.
.PARAMETER Remove
Removes all empty dirs (as in actually deletes them with Remove-Item).
.PARAMETER VerifyNoEmpty
Makes the script run until no empty directories are found. This is in order
to handle nested empty directories, as in a directory that currently only
contains an empty directory would be empty after the first run/iteration and
need to be remove in a subsequent run. Specifying this parameter causes the
script to run until it's done a complete run without finding a single empty
directory. This might be time-consuming depending on the size of the directory
tree structure.

If there is an error while deleting a directory, it will not run again, to
avoid an infinite loop.
#>

param(
    [Parameter(Mandatory=$true)][string] $Path,
    [switch] $Find,
    [switch] $Remove,
    [switch] $VerifyNoEmpty
    )

Set-StrictMode -Version 2.0
$ErrorLog   = 'remove-empty-dirs-error.log'

######## START OF FUNCTIONS ########

function Iterate-And-Remove-Empty-Dirs {
    
    $FoundEmpty = $false
    
    Write-Host "Iterating '$Path'"
    
    Get-ChildItem -Force -Recurse -Path $Path | Where-Object { $_.PSIsContainer } | ForEach-Object {
        
        if ($Find -or -not $Remove) {
            
            if (-not (Get-ChildItem -Force $_.FullName)) {
                
                # Directory should be empty
                $_.FullName + ' is empty'
                
            }
            
        }
        
        # This is the dangerous part
        elseif ($Remove) {
            
            if (-not (Get-ChildItem -Force $_.FullName)) {
                
                $FoundEmpty = $true
                
                # Directory should be empty
                Remove-Item -Force $_.FullName
                
                if (-not $?) {
                    
                    Write-Host -ForegroundColor Red "Error: $(Get-Date): Unable to delete $($_.FullName): $($Error[0].ToString))"
                    "Error: $(Get-Date): Unable to delete $($_.FullName): $($Error[0].ToString))" | Out-File -Append $ErrorLog
                    
                    $FoundEmpty = $false # avoid infinite loop
                    
                }
                
                else {
                    
                    Write-Host -ForegroundColor Green "$(Get-Date): Successfully deleted the empty folder: $($_.FullName)"
                    
                }
                
            }
            
        }
        
    } # end of ForEach-Object
    
    $FoundEmpty
    
} # end of function Iterate-And-Remove-Empty-Dirs

######## END OF FUNCTIONS ########

if (-not (Test-Path -Path $Path -PathType Container)) {
    
    "The specified path does not exist. Exiting with code 1."
    exit 1
    
}

if ($Remove -and $VerifyNoEmpty) {
    
    $Counter = 0
    
    while (($OutsideFoundEmpty = Iterate-And-Remove-Empty-Dirs) -eq $true) {
        
        $Counter++
        Write-Host -ForegroundColor Yellow "-VerifyNoEmpty specified. Found empty dirs on run no ${Counter}. Starting next run."
        
    }
    
    $Counter++
    
    Write-Host "Made $Counter runs in total"
    
}

else {
    
    Iterate-And-Remove-Empty-Dirs
    
}