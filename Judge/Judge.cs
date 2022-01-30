using System.Diagnostics;

namespace Shinpan
{
    public class Judge
    {
        private readonly IProblemInfo _problemInfo;
        private Process _process;
        private StreamWriter _output;

        public Judge(IProblemInfo problemInfo, Process process, StreamWriter output)
        {
            _problemInfo = problemInfo;
            _process = process;
            _output = output;
        }

        public void Run()
        {
            // Todo: Allow for async processing of testcases.
            foreach (var testCaseIo in _problemInfo.TestCases())
            {
                // Fixme: Can this process be reused?
                _process.Start();
                var start = _process.StartTime;

                // Writes the Inputs from TestFile into the Input of the Solution.
                _process.StandardInput.WriteLine(testCaseIo.Input);

                // Writes the Output from Solution into the output file.
                // Todo: add StdErr to output when ExitCode != 0.
                _output.Write(_process.StandardOutput.ReadToEnd());
                _process.WaitForExit();

                _output.Flush();

                // Fixme: Not used.
                var timeElapsed = (_process.ExitTime - start).Milliseconds;
                
                // Todo:
                // Store run metrics.
                // Check if constraints are met.
                // Display run metrics.
                // Display if solution is correct.
            }
        }
    }
}