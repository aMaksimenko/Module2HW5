using System.IO;
using HomeWork.Services.Abstractions;

namespace HomeWork.Services
{
    public class FileService : IFileService
    {
        ~FileService()
        {
            StreamWriter.Close();
            StreamWriter.Dispose();
        }

        private StreamWriter StreamWriter { get; set; }

        public string Read(string path)
        {
            return File.ReadAllText(path);
        }

        public void SetOutput(string path)
        {
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                fileInfo.Create().Close();
            }

            StreamWriter = new StreamWriter(path, true, System.Text.Encoding.Default);
        }

        public void Write(string data)
        {
            StreamWriter.WriteLine(data);
            StreamWriter.Flush();
        }
    }
}