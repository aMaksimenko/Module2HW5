using System;
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

        public IDisposable Create(string path)
        {
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                fileInfo.Create().Close();
            }

            return new StreamWriter(path, true, System.Text.Encoding.Default);
        }

        public void Write(IDisposable streamWriter, string data)
        {
            var sWriter = streamWriter as StreamWriter;

            sWriter?.WriteLine(data);
            sWriter?.Flush();
        }

        public void Close(IDisposable streamWriter)
        {
            var sWriter = streamWriter as StreamWriter;

            sWriter?.Close();
            sWriter?.Dispose();
        }
    }
}