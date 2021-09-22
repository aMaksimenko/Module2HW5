namespace HomeWork.Services.Abstractions
{
    public interface IFileService
    {
        public string Read(string path);
        public void SetOutput(string path);
        public void Write(string data);
    }
}