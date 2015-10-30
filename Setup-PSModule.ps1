# PowerShell module setup script (intended for use by GitHub users)
# Original Author: ramblingcookemonster
$GitHubRoot = 'C:\Users\PW82\Documents\GitHub'
$ModuleName = 'PSTextUtils'
$Path = Join-Path -Path $GitHubRoot -ChildPath $ModuleName
$Author = 'nylyst'
$Description = 'PowerShell module with a collection of useful functions for manipulating text files'

# Create the module and private function directories
mkdir $Path\$ModuleName
mkdir $Path\$ModuleName\Private
mkdir $Path\$ModuleName\Public
mkdir $Path\$ModuleName\en-US # For about_Help files
mkdir $Path\Tests

#Create the module and related files
New-Item "$Path\$ModuleName\$ModuleName.psm1" -ItemType File
New-Item "$Path\$ModuleName\$ModuleName.Format.ps1xml" -ItemType File
New-Item "$Path\$ModuleName\en-US\about_$ModuleName.help.txt" -ItemType File
New-Item "$Path\Tests\$ModuleName.Tests.ps1" -ItemType File
New-ModuleManifest -Path $Path\$ModuleName\$ModuleName.psd1 `
                   -RootModule $Path\$ModuleName\$ModuleName.psm1 `
                   -Description $Description `
                   -PowerShellVersion 3.0 `
                   -Author $Author `
                   -FormatsToProcess "$ModuleName.Format.ps1xml"

# Copy the public/exported functions into the public folder, private functions into private folder
