using System.IO;
using HomeWork.Services.Abstractions;

namespace HomeWork.Services
{
    public class FileService : IFileService
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }

        public void Create(string path)
        {
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                fileInfo.Create().Close();
            }
        }

        public void Write(StreamWriter streamWriter, string data)
        {
            streamWriter.WriteLine(data);
            streamWriter.Flush();
        }

        public void Close(StreamWriter streamWriter)
        {
            streamWriter.Close();
            streamWriter.Dispose();
        }
    }
}