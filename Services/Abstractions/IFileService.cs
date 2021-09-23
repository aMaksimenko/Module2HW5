using System.IO;

namespace HomeWork.Services.Abstractions
{
    public interface IFileService
    {
        public string Read(string path);
        public StreamWriter Create(string path);
        public void Write(StreamWriter streamWriter, string data);
        public void Close(StreamWriter streamWriter);
    }
}