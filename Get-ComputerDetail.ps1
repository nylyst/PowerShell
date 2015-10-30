#requires -Version 2
Function Get-ComputerDetail
{
    [cmdletbinding()]
    
    param (
    
        [ValidateNotNullOrEmpty()]
        [string[]]$ComputerName = $env:COMPUTERNAME
    
    )

    foreach ($node in $ComputerName)
    {
        
        try
        {
            $computerSystem		= Get-WmiObject -Class 'Win32_ComputerSystem' -ComputerName $node -ErrorAction Stop
            $computerBios		= Get-WmiObject -Class 'Win32_Bios' -ComputerName $node -ErrorAction Stop
            
            [pscustomobject][ordered]@{
                Name         	= $computerSystem.Name
                Manufacturer 	= $computerSystem.Manufacturer
                Model        	= $computerSystem.Model
                Serial       	= $computerBios.SerialNumber
            } # End of custom object
            
        } # End of try
        
        catch 
        {
            Write-Error -Message "The command failed for computer $node. Message: $_.Exception.Message"
            break
        }# End of Catch
    
    }# End of foreach

}# End of function