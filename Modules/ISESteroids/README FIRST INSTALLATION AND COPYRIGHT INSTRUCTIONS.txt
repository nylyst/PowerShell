Please read this to understand how ISESteroids needs to be installed!

To install automatically, do this:
1. Unpack the ZIP file
2. Run the file install.bat inside of the unpacked ZIP file

To install by hand, do this:
1. UNBLOCK the ZIP file before you unpack it. IMPORTANT!
2. Unpack the ZIP file
3. Copy the unpacked folder to one of the module folders listed in $env:PSModulePath. Make sure the folder you choose is not located on a network share.
4. Make sure the copied folder is named "ISESteroids"

To start ISESteroids, do this:
1. Launch the ISE editor. For example, launch PowerShell, then run the command: ise
2. Inside the ISE editor, run the command: Start-Steroids

Load ISESteroids each time you start the ISE editor:
1. Start the ISE editor, and load ISESteroids as described above.
2. When ISESteroids is loaded, click the arrow button on the far left side of the toolbar. This expands the auxiliary tool bar. 
3. In it, you find a button with a person on it. Click this button to open your profile script. It will be created if it does not yet exist.
4. Add the command Start-Steroids to your profile script, and save it.

Load ISESteroids on demand:
If you prefer to work with the default ISE from time to time, then put this piece of code into your profile script:

if ([System.Windows.Input.Keyboard]::IsKeyDown('Ctrl') -eq $false)
{
  Start-Steroids
}

When you launch ISE, ISESteroids will launch automatically UNLESS YOU HOLD THE CTRL KEY.
So if you wanted to launch ISE without ISESteroids, simply press CTRL while ISE starts.
This will skip the start command inside your profile script.

COPYRIGHT NOTICES
ISESteroids is a genuine work but partially uses open source software.
Open source software authors may demand to reproduce their original copyright notices to protect them from claims.
All of these are reproduced below.

/* 
 * Copyright (c) 2010, Andriy Syrov
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided 
 * that the following conditions are met:
 * 
 * Redistributions of source code must retain the above copyright notice, this list of conditions and the 
 * following disclaimer.
 * 
 * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and 
 * the following disclaimer in the documentation and/or other materials provided with the distribution.
 *
 * Neither the name of Andriy Syrov nor the names of his contributors may be used to endorse or promote 
 * products derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED 
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
 * PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY 
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED 
 * TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, 
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN 
 * IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
 *   
 */



