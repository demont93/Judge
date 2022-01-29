namespace Shinpan
{
    public class Script
    {
        public String? Author { get; set; }
        public String? FilePath { get; set; }
        public String? Text { get => File.ReadAllText(FilePath); }
        public int Size { get; set; }
    }
}
