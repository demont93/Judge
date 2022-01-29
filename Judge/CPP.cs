using System.Diagnostics;

namespace Shinpan
{
    public class CPP : CompiledLanguage
    {


        public CPP()
        {
            OutputFile = "./a.out";
            CompilerInterpreterPath = "/usr/bin/g++";
            CompilerInterpreterArgs = "-g -O2 -o " + OutputFile + "-std=gnu++17 -static ${files}";

            StartInfo.FileName = OutputFile;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardInput = true;
        }

       /* public override Process RunScript()
        {
            throw new NotImplementedException();
        }*/
    }
}
