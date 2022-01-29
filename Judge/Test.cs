using System.Diagnostics;

namespace Shinpan
{
    /// <summary>
    ///  Tests the user's solution several times using a file which may contain a set of 
    /// possible inputs and gives back useful information for the Judge class to use
    /// </summary>
    public class Test
    {
        public Process? SolutionProcess { get; private set; }
        private StreamWriter Output { get; set; } //Test output
        private StreamReader Input { get; set; } //Test input
        public DateTime ProcessedAt { get; private set; } //Time the test was made
        private string TestFile { get; set; }
        public int TimeElapsed { get; private set; }


        /// <param name="solutionProcess"> Process of the user's solution before running.</param>
        /// <param name="testFile"> File from which Test will take the inputs of the Game set</param>
        public Test(Process solutionProcess, string testFile)
        {

            SolutionProcess = solutionProcess;
            TestFile = testFile;

            InitialConditions();

            // In and Out can be not only from file (Fix)
            Output = new StreamWriter("./Tests/output");
            Input = new StreamReader(TestFile);

            DateTime start;

            SolutionProcess.Start();

            start = SolutionProcess.StartTime;

            //Writes the Inputs frm TestFile into the Input of the Solution
            SolutionProcess.StandardInput.WriteLine(Input.ReadToEnd()); 

            //Writes the Ouput frm Solution into the output file
            //Fix add Standard Error to output when ExitCode != 0
            Output.Write(SolutionProcess.StandardOutput.ReadToEnd());

            SolutionProcess.WaitForExit();

            ProcessedAt = DateTime.Now;

            Output.Flush();
            
            //Too long for the actual process
            TimeElapsed = (SolutionProcess.ExitTime - start).Milliseconds ; 
        }


        private void InitialConditions()
        {
            if (SolutionProcess == null)
                throw new ArgumentNullException("Not a valid process (null) ");

            if (TestFile == null)
                throw new ArgumentNullException("Test File should have a value");

            var StartInfo = SolutionProcess.StartInfo;

            if (!(StartInfo.RedirectStandardOutput && StartInfo.RedirectStandardInput))
                throw new ArgumentException("The solution process should have stdout, stdin and stderr redirected");
        }
    }
}
