using System.IO;

namespace SRP.Examples.Example01
{
    // Does this class follow the single responsibility principle?
    public class FileReader
    {
        public string ReadAllTextFrom(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}