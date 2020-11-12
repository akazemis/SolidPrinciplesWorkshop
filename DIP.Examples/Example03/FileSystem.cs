using System.IO;

namespace DIP.Examples.Example03
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