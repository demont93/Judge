using System.Diagnostics;

namespace Shinpan
{
    public abstract class CompiledLanguage : Language
    {
        public override int CompileScript() 
        {
            Process pProcess = new Process();
            pProcess.StartInfo.FileName = CompilerInterpreterPath;
            pProcess.StartInfo.Arguments = CompilerInterpreterArgs;
            pProcess.StartInfo.UseShellExecute = true;
            pProcess.Start();

            if (pProcess == null)
                throw new Exception(this.GetType() + " could not execute the process");

            else if ( pProcess.ExitCode != 0)
                throw new Exception("The process ended bad as fuck");

            else pProcess.WaitForExit();

            return pProcess.ExitCode;
        }

    }
}
