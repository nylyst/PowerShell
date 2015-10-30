# Edit This item to change the DropDown Values 
[array]$DropDownArray = "ping", "nslookup", "BIOS", "Services", "Programs", "RemoteUninstall", "RemoteInstall", "MapNetworkDrive" 
 
# This Function Returns the Selected Value and their actions then Closes the Form 
function Return-DropDown { 
    $Choice = $DropDown.SelectedItem.ToString() 
    $Address = $Address.Text 
    #$Form.Close() 
        if ($choice -eq "ping")  
        { 
            write-host "PING $address" 
            Test-Connection $address | Out-gridview 
            write-host 
        } 
        elseif ($choice -eq "nslookup")  
        { 
            write-host "NSLOOKUP $address" 
            nslookup $address | Out-gridview 
            write-host 
        }         
        elseif ($choice -eq "BIOS")  
        { 
            write-host "BIOS of $address" 
            Get-WmiObject win32_bios -ComputerName $address | Out-gridview 
            write-host 
        }    
        elseif ($choice -eq "Services")  
        { 
            write-host "Services of $address" 
            Get-WmiObject win32_service -ComputerName $address | Out-gridview 
            write-host 
        }    
        elseif ($choice -eq "Programs")  
        { 
            write-host "Programs installed on $address" 
            Get-WmiObject win32_product -ComputerName $address | Out-gridview 
            write-host 
        }         
        elseif ($choice -eq "RemoteUninstall")  
        { 
           $objForm = New-Object System.Windows.Forms.Form  
            $objForm.Text = "Data Entry Form" 
            $objForm.Size = New-Object System.Drawing.Size(300,200)  
            $objForm.StartPosition = "CenterScreen" 
 
            $objForm.KeyPreview = $True 
            $objForm.Add_KeyDown({if ($_.KeyCode -eq "Enter")  
                    {$y=$objTextBox.Text;$objForm.Close()}}) 
            $objForm.Add_KeyDown({if ($_.KeyCode -eq "Escape")  
                    {$objForm.Close()}}) 
 
            $OKButton = New-Object System.Windows.Forms.Button 
            $OKButton.Location = New-Object System.Drawing.Size(75,120) 
            $OKButton.Size = New-Object System.Drawing.Size(75,23) 
            $OKButton.Text = "OK" 
            $OKButton.Add_Click({$location=$objTextBox.Text;$objForm.Close()}) 
            $objForm.Controls.Add($OKButton) 
 
            $CancelButton = New-Object System.Windows.Forms.Button 
            $CancelButton.Location = New-Object System.Drawing.Size(150,120) 
            $CancelButton.Size = New-Object System.Drawing.Size(75,23) 
            $CancelButton.Text = "Cancel" 
            $CancelButton.Add_Click({$objForm.Close()}) 
            $objForm.Controls.Add($CancelButton) 
 
            $objLabel = New-Object System.Windows.Forms.Label 
            $objLabel.Location = New-Object System.Drawing.Size(10,20)  
            $objLabel.Size = New-Object System.Drawing.Size(280,20)  
            $objLabel.Text = "Name of the application to be uninstalled:" 
            $objForm.Controls.Add($objLabel)  
             
            $objLabel2 = New-Object System.Windows.Forms.Label 
            $objLabel2.Location = New-Object System.Drawing.Size(10,50)  
            $objLabel2.Size = New-Object System.Drawing.Size(190,20)  
            $objLabel2.Text = "Don't be too generic!" 
            $objForm.Controls.Add($objLabel2)  
 
            $objTextBox = New-Object System.Windows.Forms.TextBox  
            $objTextBox.Location = New-Object System.Drawing.Size(10,80)  
            $objTextBox.Size = New-Object System.Drawing.Size(260,20)  
            $objForm.Controls.Add($objTextBox)  
 
            $objForm.Topmost = $True 
 
            $objForm.Add_Shown({$objForm.Activate()}) 
            [void] $objForm.ShowDialog() 
             
            Try{ 
            $app = Get-WmiObject win32_product -ComputerName $Address -ErrorAction SilentlyContinue | Where-Object {$_.name -match $location} 
            $returnvalue = $app.uninstall() | Select-Object -Property returnvalue -ErrorAction SilentlyContinue 
             
                if($returnvalue.returnvalue -eq "0") 
                    {[Windows.Forms.MessageBox]::Show("Installation was successful!")} 
                     
                else 
                    {[Windows.Forms.MessageBox]::Show("Installation was not successful!")}} 
                     
            Catch{ 
                if($error[0] -match "The RPC server is unavailable" -or $error[0] -match "null-valued"){ 
                    [Windows.Forms.MessageBox]::Show("Computer is unreachable, name is invalid or application does not exist.")}} 
        }    
        elseif ($choice -eq "RemoteInstall")  
        {     
                 
               $objForm = New-Object System.Windows.Forms.Form  
            $objForm.Text = "Data Entry Form" 
            $objForm.Size = New-Object System.Drawing.Size(300,200)  
            $objForm.StartPosition = "CenterScreen" 
 
            $objForm.KeyPreview = $True 
            $objForm.Add_KeyDown({if ($_.KeyCode -eq "Enter")  
                    {$y=$objTextBox.Text;$objForm.Close()}}) 
            $objForm.Add_KeyDown({if ($_.KeyCode -eq "Escape")  
                    {$objForm.Close()}}) 
 
            $OKButton = New-Object System.Windows.Forms.Button 
            $OKButton.Location = New-Object System.Drawing.Size(75,120) 
            $OKButton.Size = New-Object System.Drawing.Size(75,23) 
            $OKButton.Text = "OK" 
            $OKButton.Add_Click({$location=$objTextBox.Text;$objForm.Close()}) 
            $objForm.Controls.Add($OKButton) 
 
            $CancelButton = New-Object System.Windows.Forms.Button 
            $CancelButton.Location = New-Object System.Drawing.Size(150,120) 
            $CancelButton.Size = New-Object System.Drawing.Size(75,23) 
            $CancelButton.Text = "Cancel" 
            $CancelButton.Add_Click({$objForm.Close()}) 
            $objForm.Controls.Add($CancelButton) 
 
            $objLabel = New-Object System.Windows.Forms.Label 
            $objLabel.Location = New-Object System.Drawing.Size(10,20)  
            $objLabel.Size = New-Object System.Drawing.Size(280,20)  
            $objLabel.Text = "UNC path for the application to be installed:" 
            $objForm.Controls.Add($objLabel)  
             
            $objLabel2 = New-Object System.Windows.Forms.Label 
            $objLabel2.Location = New-Object System.Drawing.Size(10,50)  
            $objLabel2.Size = New-Object System.Drawing.Size(190,20)  
            $objLabel2.Text = "Eg: \\computername\c$\firefox.msi" 
            $objForm.Controls.Add($objLabel2)  
 
            $objTextBox = New-Object System.Windows.Forms.TextBox  
            $objTextBox.Location = New-Object System.Drawing.Size(10,80)  
            $objTextBox.Size = New-Object System.Drawing.Size(260,20)  
            $objForm.Controls.Add($objTextBox)  
 
            $objForm.Topmost = $True 
 
            $objForm.Add_Shown({$objForm.Activate()}) 
            [void] $objForm.ShowDialog() 
             
            Try{ 
            $returnvalue = (Get-WmiObject -ComputerName $Address -List -ErrorAction SilentlyContinue | Where-Object -FilterScript {$_.Name -eq "win32_product"}).install($location) | Select-Object -Property returnvalue 
                 
                if($returnvalue.returnvalue -eq "0") 
                    {[Windows.Forms.MessageBox]::Show("Installation was successful!")} 
                 
                else 
                    {[Windows.Forms.MessageBox]::Show("Installation was not successful!")} 
            } 
            Catch{ 
                if($error[0] -match "The RPC server is unavailable" -or $error[0] -match "null-valued"){ 
                    [Windows.Forms.MessageBox]::Show("Computer is unreachable, name is invalid or application does not exist.")}} 
             
        } 
        elseif ($Choice -eq "MapNetworkDrive") 
        { 
             
            $objForm = New-Object System.Windows.Forms.Form  
            $objForm.Text = "Data Entry Form" 
            $objForm.Size = New-Object System.Drawing.Size(300,200)  
            $objForm.StartPosition = "CenterScreen" 
 
            $objForm.KeyPreview = $True 
            $objForm.Add_KeyDown({if ($_.KeyCode -eq "Enter")  
                    {$y=$objTextBox.Text;$objForm.Close()}}) 
            $objForm.Add_KeyDown({if ($_.KeyCode -eq "Escape")  
                    {$objForm.Close()}}) 
 
            $OKButton = New-Object System.Windows.Forms.Button 
            $OKButton.Location = New-Object System.Drawing.Size(75,120) 
            $OKButton.Size = New-Object System.Drawing.Size(75,23) 
            $OKButton.Text = "OK" 
            $OKButton.Add_Click({$y=$objTextBox.Text;$objForm.Close()}) 
            $objForm.Controls.Add($OKButton) 
 
            $CancelButton = New-Object System.Windows.Forms.Button 
            $CancelButton.Location = New-Object System.Drawing.Size(150,120) 
            $CancelButton.Size = New-Object System.Drawing.Size(75,23) 
            $CancelButton.Text = "Cancel" 
            $CancelButton.Add_Click({$objForm.Close()}) 
            $objForm.Controls.Add($CancelButton) 
 
            $objLabel = New-Object System.Windows.Forms.Label 
            $objLabel.Location = New-Object System.Drawing.Size(10,20)  
            $objLabel.Size = New-Object System.Drawing.Size(280,20)  
            $objLabel.Text = "Letter of new Network Drive:" 
            $objForm.Controls.Add($objLabel)  
 
            $objTextBox = New-Object System.Windows.Forms.TextBox  
            $objTextBox.Location = New-Object System.Drawing.Size(10,40)  
            $objTextBox.Size = New-Object System.Drawing.Size(260,20)  
            $objForm.Controls.Add($objTextBox)  
 
            $objForm.Topmost = $True 
 
            $objForm.Add_Shown({$objForm.Activate()}) 
            [void] $objForm.ShowDialog() 
             
            $x = $y 
 
            $objTextBox.clear() 
            $objLabel.Text = "UNC:" 
            $objForm.Controls.Add($objLabel) 
            $objForm.Controls.Add($objTextBox)  
            $objForm.Add_Shown({$objForm.Activate()}) 
            [void] $objForm.ShowDialog() 
 
            $map = New-Object -ComObject wscript.network 
                if($x -match ":"){Try{$map.MapNetworkDrive($x,$y)}Catch{if($error[0] -match "The local device"){[Windows.Forms.MessageBox]::Show("The local device is already in use.")}else{[Windows.Forms.MessageBox]::Show("The network name cannot be found.")}}} 
                else 
                {Try{$x = $x+":"; $map.MapNetworkDrive($x,$y)}Catch{if($error[0] -match "The local device"){[Windows.Forms.MessageBox]::Show("The local device is already in use.")}else{[Windows.Forms.MessageBox]::Show("The network name cannot be found.")}}} 
 
 
            } 
} 
 
[System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms") 
[System.Reflection.Assembly]::LoadWithPartialName("System.Drawing") 
 
$Form = New-Object System.Windows.Forms.Form 
 
$Form.width = 300 
$Form.height = 250 
$Form.Text = "Network Tools" 
$Form.maximumsize = New-Object System.Drawing.Size(300,250) 
$Form.startposition = "centerscreen" 
$Form.KeyPreview = $True 
$Form.Add_KeyDown({if ($_.KeyCode -eq "Enter")  
    {return-dropdown}}) 
$Form.Add_KeyDown({if ($_.KeyCode -eq "Escape")  
    {$Form.Close()}}) 
 
 
 
$DropDown = new-object System.Windows.Forms.ComboBox 
$DropDown.Location = new-object System.Drawing.Size(100,10) 
$DropDown.Size = new-object System.Drawing.Size(130,30) 
 
ForEach ($Item in $DropDownArray) { 
    $DropDown.Items.Add($Item) 
} 
 
$Form.Controls.Add($DropDown) 
 
 
$DropDownLabel = new-object System.Windows.Forms.Label 
$DropDownLabel.Location = new-object System.Drawing.Size(10,10) 
$DropDownLabel.size = new-object System.Drawing.Size(100,20) 
$DropDownLabel.Text = "Command" 
$Form.Controls.Add($DropDownLabel) 
 
$Button = new-object System.Windows.Forms.Button 
$Button.Location = new-object System.Drawing.Size(100,150) 
$Button.Size = new-object System.Drawing.Size(100,20) 
$Button.Text = "OK" 
$Button.Add_Click({Return-DropDown}) 
$form.Controls.Add($Button) 
 
$address = new-object System.Windows.Forms.TextBox 
$address.Location = new-object System.Drawing.Size(100,100) 
$address.Size = new-object System.Drawing.Size(100,20) 
 
$Form.Controls.Add($address) 
 
$addresslabel = new-object System.Windows.Forms.Label 
$addresslabel.Location = new-object System.Drawing.Size(10,100) 
$addresslabel.size = new-object System.Drawing.Size(100,20) 
$addresslabel.Text = "Computer" 
$Form.Controls.Add($addresslabel) 
 
$authorlabel = new-object System.Windows.Forms.Label 
$authorlabel.Location = new-object System.Drawing.Size(160,185) 
$authorlabel.size = new-object System.Drawing.Size(200,15) 
$authorlabel.Text = "Powered by F. Binotto." 
$Form.Controls.Add($authorlabel) 
 
$Form.Add_Shown({$Form.Activate()}) 
$Form.ShowDialog() 