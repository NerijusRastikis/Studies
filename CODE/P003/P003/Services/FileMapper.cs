using P003.DTO;
using P003.Models;

namespace P003.Services
{
    public class FileMapper : IFileMapper
    {
        public FileMapper()
        {

        }
        public IEnumerable<FileLineResult> Map(IEnumerable<string> lines)
        {
            int iterator = 0;
            var capturedLines = new List<FileLineResult>();

            foreach (var line in lines)
            {
                var newLine = new FileLineResult
                {
                    Id = iterator + 1,
                    Content = line
                };

                capturedLines.Add(newLine);
                iterator++;
            }

            return capturedLines;
        }
        public FileLineResult MapToResult(string line)
        {
            return new FileLineResult
            {
                Id = 1,
                Content = line
            };
        }

        public FileLineRequest MapToRequest(string line)
        {
            return new FileLineRequest
            {
                Content = line
            };
        }
        public void Project(string item, string req)
        {
            item = req;
        }
    }
}
