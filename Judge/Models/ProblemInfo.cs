namespace Shinpan
{
    interface IProblemInfo
    {
        public string GetDescription();
        public IEnumerable<TestCaseIo> TestCases();
        public ulong GetExecutionMemoryKb();
        public ulong GetCompilationMemoryKb();
        public ulong GetExecutionTimeS();
        public ulong GetCompilationTimeS();
        public ulong GetSolutionFileSizeKb();
    }

    public class ProblemInfo : IProblemInfo
    {
        public ProblemInfo(
            ulong executionMemoryKb, ulong compilationMemoryKb,
            ulong executionTimeS, ulong compilationTimeS,
            ulong solutionFileSizeKb, string description, List<string> inputs,
            List<string> outputs
        )
        {
            _executionMemoryKb = executionMemoryKb;
            _compilationMemoryKb = compilationMemoryKb;
            _executionTimeS = executionTimeS;
            _compilationTimeS = compilationTimeS;
            _solutionFileSizeKb = solutionFileSizeKb;
            _description = description;
            _inputs = inputs;
            _outputs = outputs;
        }

        private readonly string _description;
        private readonly List<string> _inputs;
        private readonly List<string> _outputs;
        private readonly ulong _executionMemoryKb;
        private readonly ulong _compilationMemoryKb;
        private readonly ulong _executionTimeS;
        private readonly ulong _compilationTimeS;
        private readonly ulong _solutionFileSizeKb;

        public string GetDescription()
        {
            return _description;
        }

        public IEnumerable<TestCaseIo> TestCases()
        {
            return _inputs.Zip(_outputs,
                (i, o) => new TestCaseIo {Input = i, Output = o}
            );
        }

        public ulong GetExecutionMemoryKb()
        {
            return _executionMemoryKb;
        }

        public ulong GetCompilationMemoryKb()
        {
            return _compilationMemoryKb;
        }

        public ulong GetExecutionTimeS()
        {
            return _executionTimeS;
        }

        public ulong GetCompilationTimeS()
        {
            return _compilationTimeS;
        }

        public ulong GetSolutionFileSizeKb()
        {
            return _solutionFileSizeKb;
        }
    }

    public struct TestCaseIo
    {
        public string Input;
        public string Output;
    }
}