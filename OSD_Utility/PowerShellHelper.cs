using System;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.Text;

namespace OSD_Utility
{
    public class PowerShellHelper
    {
        public static void ExecuteCMDCommand(string arguments)
        {
            // Configure the PowerShell execution policy to run script
            using (System.Management.Automation.PowerShell PowerShellInstance = System.Management.Automation.PowerShell.Create())
            {
                string script = "Set-ExecutionPolicy -Scope currentuser -ExecutionPolicy bypass; Get-ExecutionPolicy"; // the second command to know the ExecutionPolicy level
                PowerShellInstance.AddScript(script);
                var someResult = PowerShellInstance.Invoke();
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "CMD.exe";
            startInfo.Verb = "runas";
            startInfo.Arguments = arguments;
            System.Diagnostics.Process.Start(startInfo);
        }

        public static string RunScript(string scriptText)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);

            pipeline.Commands.Add("Out-String");
            Collection<PSObject> results = pipeline.Invoke();
            runspace.Close();

            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
