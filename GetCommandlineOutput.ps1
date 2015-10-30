$assem = (
"System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
"System.Collections, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
)

$source = @"
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace GetCommandlineOutput
{
    public static class RunCommand
    {
        public static void Run()
        {
			string[] space = new string[] {" "};
			string[] cr = new string[] {Environment.NewLine};

			Process p = new Process();
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.RedirectStandardOutput = true;
			p.StartInfo.CreateNoWindow = true;
			p.StartInfo.FileName = "C:\\Users\\PW82\\Documents\\Desktop Shortcuts Backup\\Non-Root VS 2013.lnk";
			//p.StartInfo.Arguments = "devices -l";
			p.Start();
			string output = p.StandardOutput.ReadToEnd();
			p.WaitForExit();
			output = output.Remove(0, 27);
			foreach (string line in output.Split(cr, StringSplitOptions.RemoveEmptyEntries))
			{
                Console.WriteLine(line);
			}
        }
    }
}
"@

Add-Type -ReferencedAssemblies $Assem -TypeDefinition $Source -Language CSharp

[GetCommandlineOutput.RunCommand]::Run()