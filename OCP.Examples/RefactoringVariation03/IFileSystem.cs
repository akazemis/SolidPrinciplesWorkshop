namespace OCP.Examples.RefactoringVariation03
{
    public interface IFileSystem
    {
        string ReadAllText(string filename);
        void WriteAllText(string filename, string text);
    }
}