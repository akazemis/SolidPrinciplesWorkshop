namespace OCP.Examples.RefactoringVariation02
{
    public interface IFileSystem
    {
        string ReadAllText(string filename);
        void WriteAllText(string filename, string text);
    }
}