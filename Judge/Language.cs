using System.Diagnostics;

namespace Shinpan
{
    public abstract class Language : Process 
    {
        //TODO "(sb-ext:save-lisp-and-die" + script.name() + ":executable t: toplevel 'main)";
        protected string? OutputFile { get; set; } //For compiled langs
        protected string? CompilerInterpreterPath { get; set; }
        protected string? CompilerInterpreterArgs { get; set; }

        /*public String RunScript(GameSet gs) 
        {
            if (GetType().ToString() == "CompiledLanguage")
                CompileScript();

            Start();

            FileStream fs = File.Create(output_dir, 5000);

            fs.Close();

            StreamWriter stdin = StandardInput;
            StreamReader stderr = StandardError;

            while(!HasExited)
            {
                Console.WriteLine("Working on a script ...");
                stdin.WriteLine(gs.NextInput());
                File.WriteAllText(output_dir, StandardOutput.ReadLine());
            }

            return output_dir;
        }*/

        virtual public int CompileScript()
        {
            throw new NotImplementedException();
        }

    }
}
