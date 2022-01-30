using System.Diagnostics;

namespace Shinpan
{
    public class Judge
    {
        private readonly ProblemInfo _problem;

        public Judge (ProblemInfo problemInfo, Script script, Language language)
        {

            //Language lang = DetectLanguage();
            //lang.RunScript(_problem.gameSet);
        }

        /*
        private Language DetectLanguage() 
        {
            return Path.GetExtension(this._script.FilePath) switch
            {
                //"lisp" => new CPP(),
                "cc" or "cpp" => new CPP(),
                _ => throw new Exception("Language compiling not implemented"),
            };
        }*/
    }
}
