namespace P003.Services
{
    public interface IFileService
    {
        string[] ReadAllLines();
        string? ReadLine(int id);
        bool RemoveLine(int id);
        bool ReplaceLine(string content, int id);
        bool WriteLine(string content);
        public bool UserExists(string Id);
    }
}