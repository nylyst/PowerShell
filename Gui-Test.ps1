function UpdateProcCount($Label)
{
    $Label.Text = "New of processes running on my computer: " + (Get-Process | measure).Count
}

#Add-Type -AssemblyName System.Windows.Forms
$Form = New-Object System.Windows.Forms.Form
$timer = New-Object System.Windows.Forms.Timer
$timer.Interval = 1000
$timer.Add_Tick({UpdateProcCount $Label})
$timer.Enabled = $True
#$Form.Controls.Add($timer)
#$button = New-Object System.Windows.Forms.Button
#$button.Text = "Enable"
#$button.Add_Click({$timer.Enabled = not $timer.Enabled})
#$Form.Controls.Add($button)
#$buttonEnd = New-Object System.Windows.Forms.Button
#$buttonEnd.Text = "Exit"
#$buttonEnd.Add_Click({Exit})
#$Form.Controls.Add($buttonEnd)
$Form.Text = "Sample Form"
$Label = New-Object System.Windows.Forms.Label
$Label.Text = "Number of process executed on my computer"
$Label.AutoSize = $True
$Form.Controls.Add($Label)

