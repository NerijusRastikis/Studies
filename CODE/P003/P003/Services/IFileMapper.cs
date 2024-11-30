using P003.DTO;

namespace P003.Services
{
    public interface IFileMapper
    {
        IEnumerable<FileLineResult> Map(IEnumerable<string> lines);
        FileLineRequest MapToRequest(string line);
        FileLineResult MapToResult(string line);
        void Project(string item, string req);
    }
}