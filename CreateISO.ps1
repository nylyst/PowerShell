# Author: Hrisan Dzhankardashliyski 
# Date: 20/05/2015 
 
# Inspiration from 
# 
#   http://blogs.msdn.com/b/opticalstorage/archive/2010/08/13/writing-optical-discs-using-imapi-2-in-powershell.aspx 
# 
# and 
# 
#   http://tools.start-automating.com/Install-ExportISOCommand/ 
# 
# with help from 
# 
#   http://stackoverflow.com/a/9802807/223837 
 
$InputFolder = "" 
 
function WriteIStreamToFile([__ComObject] $istream, [string] $fileName) 
{ 
    # NOTE: We cannot use [System.Runtime.InteropServices.ComTypes.IStream], 
    # since PowerShell apparently cannot convert an IStream COM object to this 
    # Powershell type.  (See http://stackoverflow.com/a/9037299/223837 for 
    # details.) 
    # 
    # It turns out that .NET/CLR _can_ do this conversion. 
    # 
    # That is the reason why method FileUtil.WriteIStreamToFile(), below, 
    # takes an object, and casts it to an IStream, instead of directly 
    # taking an IStream inputStream argument. 
 
    $cp = New-Object CodeDom.Compiler.CompilerParameters              
    $cp.CompilerOptions = "/unsafe" 
    $cp.WarningLevel = 4 
    $cp.TreatWarningsAsErrors = $true 
 
    Add-Type -CompilerParameters $cp -TypeDefinition @" 
        using System; 
        using System.IO; 
        using System.Runtime.InteropServices.ComTypes; 
 
        namespace My 
        { 
 
            public static class FileUtil { 
                public static void WriteIStreamToFile(object i, string fileName) { 
                    IStream inputStream = i as IStream; 
                    FileStream outputFileStream = File.OpenWrite(fileName); 
                    int bytesRead = 0; 
                    int offset = 0; 
                    byte[] data; 
                    do { 
                        data = Read(inputStream, 2048, out bytesRead);   
                        outputFileStream.Write(data, 0, bytesRead); 
                        offset += bytesRead; 
                    } while (bytesRead == 2048); 
                    outputFileStream.Flush(); 
                    outputFileStream.Close(); 
                } 
 
                unsafe static private byte[] Read(IStream stream, int toRead, out int read) { 
                    byte[] buffer = new byte[toRead]; 
                    int bytesRead = 0; 
                    int* ptr = &bytesRead; 
                    stream.Read(buffer, toRead, (IntPtr)ptr);    
                    read = bytesRead; 
                    return buffer; 
                }  
            } 
 
        } 
"@ 
 
    [My.FileUtil]::WriteIStreamToFile($istream, $fileName) 
} 
 
 
# The Function defines the ISO parameters and writes it to file 
function createISO([string]$VolName,[string]$Folder,[bool]$IncludeRoot,[string]$ISOFile){ 
 
# Constants from http://msdn.microsoft.com/en-us/library/windows/desktop/aa364840.aspx 
$FsiFileSystemISO9660   = 1 
$FsiFileSystemJoliet    = 2 
$FsiFileSystemUDF      = 4 
 
$fsi = New-Object -ComObject IMAPI2FS.MsftFileSystemImage 
 
#$fsi.FileSystemsToCreate = $FsiFileSystemISO9660 + $FsiFileSystemJoliet 
 
$fsi.FileSystemsToCreate = $FsiFileSystemUDF 
#When FreeMediaBlocks is set to 0 it allows the ISO file to be with unlimited size 
$fsi.FreeMediaBlocks = 0 
$fsi.VolumeName = $VolName 
 
$fsi.Root.AddTree($Folder, $IncludeRoot) 
 
WriteIStreamToFile $fsi.CreateResultImage().ImageStream $ISOFile 
} 
 
Function Get-Folder($initialDirectory) 
 
{ 
    [System.Reflection.Assembly]::LoadWithPartialName("System.windows.forms") 
 
    $foldername = New-Object System.Windows.Forms.FolderBrowserDialog 
    $foldername.rootfolder = "MyComputer" 
 
    if($foldername.ShowDialog() -eq "OK") 
    { 
        $folder += [string]$foldername.SelectedPath 
    } 
    return $folder 
} 
 
# Show an Open Folder Dialog and return the directory selected by the user.  
function Read-FolderBrowserDialog([string]$Message, [string]$InitialDirectory, [switch]$NoNewFolderButton) 
{ 
     $browseForFolderOptions = 0      
     if ($NoNewFolderButton) { $browseForFolderOptions += 512 } 
     $app = New-Object -ComObject Shell.Application 
     $folder = $app.BrowseForFolder(0, $Message, $browseForFolderOptions, $InitialDirectory) 
     if ($folder) { $selectedDirectory = $folder.Self.Path } 
      else { $selectedDirectory = '' } 
     [System.Runtime.Interopservices.Marshal]::ReleaseComObject($app) > $null 
     return $selectedDirectory 
} 
 
#Prompts the user to save the ISO file, if the files does not exists it will create it otherwise overwrite without prompt 
Function Get-SaveFile($initialDirectory) 
{  
[System.Reflection.Assembly]::LoadWithPartialName("System.windows.forms") | 
Out-Null 
 
$SaveFileDialog = New-Object System.Windows.Forms.SaveFileDialog 
$SaveFileDialog.CreatePrompt = $false 
$SaveFileDialog.OverwritePrompt = $false  
$SaveFileDialog.initialDirectory = $initialDirectory 
$SaveFileDialog.filter = "ISO files (*.iso)| *.iso" 
$SaveFileDialog.ShowHelp = $true 
$SaveFileDialog.ShowDialog() | Out-Null 
$SaveFileDialog.filename 
} 
 
# Show message box popup and return the button clicked by the user.  
function Read-MessageBoxDialog([string]$Message, [string]$WindowTitle, [System.Windows.Forms.MessageBoxButtons]$Buttons = [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]$Icon = [System.Windows.Forms.MessageBoxIcon]::None)  
{  
    Add-Type -AssemblyName System.Windows.Forms  
    return [System.Windows.Forms.MessageBox]::Show($Message, $WindowTitle, $Buttons, $Icon)  
} 
 
# GUI interface for the PowerShell script 
[void] [System.Reflection.Assembly]::LoadWithPartialName("System.Drawing")  
[void] [System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms")  #loading the necessary .net libraries (using void to suppress output) 
 
$Form = New-Object System.Windows.Forms.Form    #creating the form (this will be the "primary" window) 
$Form.Text = "ISO Creator Tool:" 
$Form.Size = New-Object System.Drawing.Size(600,300)  #the size in px of the window length, height 
$Form.FormBorderStyle = 'FixedDialog' 
$Form.MaximizeBox = $false 
$Form.MinimizeBox = $false 
 
$objLabel = New-Object System.Windows.Forms.Label 
$objLabel.Location = New-Object System.Drawing.Size(20,20)  
$objLabel.Size = New-Object System.Drawing.Size(120,20)  
$objLabel.Text = "Please select a Folder:" 
$Form.Controls.Add($objLabel)  
 
$InputBox = New-Object System.Windows.Forms.TextBox  
$InputBox.Location = New-Object System.Drawing.Size(150,20)  
$InputBox.Size = New-Object System.Drawing.Size(300,20) 
$InputBox.Enabled = $false  
$Form.Controls.Add($InputBox)  
 
$objLabel2 = New-Object System.Windows.Forms.Label 
$objLabel2.Location = New-Object System.Drawing.Size(20,80)  
$objLabel2.Size = New-Object System.Drawing.Size(120,20) 
$objLabel2.Text = "ISO File Name:" 
$Form.Controls.Add($objLabel2)  
 
$InputBox2 = New-Object System.Windows.Forms.TextBox  
$InputBox2.Location = New-Object System.Drawing.Size(150,80)  
$InputBox2.Size = New-Object System.Drawing.Size(300,20) 
$InputBox2.Enabled = $false  
$Form.Controls.Add($InputBox2)  
 
$objLabel3 = New-Object System.Windows.Forms.Label 
$objLabel3.Location = New-Object System.Drawing.Size(20,50)  
$objLabel3.Size = New-Object System.Drawing.Size(120,20) 
$objLabel3.Text = "ISO Volume Name:" 
$Form.Controls.Add($objLabel3)  
 
$InputBox3 = New-Object System.Windows.Forms.TextBox  
$InputBox3.Location = New-Object System.Drawing.Size(150,50)  
$InputBox3.Size = New-Object System.Drawing.Size(150,20) 
$Form.Controls.Add($InputBox3) 
 
$objLabel4 = New-Object System.Windows.Forms.Label 
$objLabel4.Location = New-Object System.Drawing.Size(20,120)  
$objLabel4.Size = New-Object System.Drawing.Size(120,20) 
$objLabel4.Text = "Status Msg:" 
$Form.Controls.Add($objLabel4)  
 
$InputBox4 = New-Object System.Windows.Forms.TextBox  
$InputBox4.Location = New-Object System.Drawing.Size(150,120)  
$InputBox4.Size = New-Object System.Drawing.Size(200,20) 
$InputBox4.Enabled = $false 
$InputBox4.Text = "Set ISO Parameters..." 
$InputBox4.BackColor = "LimeGreen" 
$Form.Controls.Add($InputBox4) 
 
$Button = New-Object System.Windows.Forms.Button  
$Button.Location = New-Object System.Drawing.Size(470,20)  
$Button.Size = New-Object System.Drawing.Size(80,20)  
$Button.Text = "Browse"  
$Button.Add_Click({ 
    $InputBox.Text=Read-FolderBrowserDialog 
    $InputBox4.Text = "Set ISO Parameters..." 
 
})  
$Form.Controls.Add($Button) 
 
$Button2 = New-Object System.Windows.Forms.Button  
$Button2.Location = New-Object System.Drawing.Size(470,120)  
$Button2.Size = New-Object System.Drawing.Size(80,80)  
$Button2.Text = "CreateISO"  
$Button2.Add_Click({ 
 
    if(($InputBox.Text -eq "") -or ($InputBox3.Text -eq "")){ 
     
        Read-MessageBoxDialog "You have to select folder and specify ISO Volume Name" "Error: No Parameters entered!" 
     
    } else{ 
     
        $SaveDialog = Get-SaveFile 
        #If you click cancel when save file dialog is called  
        if ($SaveDialog -eq ""){ 
            return 
        } 
        $InputBox2.Text= $SaveDialog 
        $InputBox2.Refresh() 
     
        if($checkBox1.Checked){ 
              $includeRoot=$true 
         } 
         else{ 
             $includeRoot=$false 
         } 
    $InputBox4.BackColor = "Red" 
    $InputBox4.Text = "Generating ISO File!" 
    $InputBox4.Refresh() 
     
    createISO $InputBox3.Text $InputBox.Text $includeRoot $InputBox2.Text 
     
    $InputBox4.BackColor = "LimeGreen" 
    $InputBox4.Text = "ISO Creation Finished!" 
    $InputBox4.Refresh() 
     
    } 
     
})  
$Form.Controls.Add($Button2) 
 
$objLabel5 = New-Object System.Windows.Forms.Label 
$objLabel5.Location = New-Object System.Drawing.Size(20,160)  
$objLabel5.Size = New-Object System.Drawing.Size(280,20) 
$objLabel5.Text = "Check the box if you want to include the top folder:" 
$Form.Controls.Add($objLabel5)  
 
$checkBox1 = New-Object System.Windows.Forms.CheckBox 
$checkBox1.Location = New-Object System.Drawing.Size(300,156)  
$Form.Controls.Add($checkBox1) 
 
$Form.Add_Shown({$Form.Activate()}) 
[void] $Form.ShowDialog() 