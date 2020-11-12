using System.IO;

namespace OCP.Examples.RefactoringVariation02
{
    public class FileSystem : IFileSystem
    {
        public string ReadAllText(string filename)
        {
            return File.ReadAllText(filename);
        }

        public void WriteAllText(string filename, string text)
        {
            File.WriteAllText(filename, text);
        }
    }
}