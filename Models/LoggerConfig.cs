namespace HomeWork.Models
{
    public class LoggerConfig
    {
        public string TimeFormat { get; init; }
        public string DirectoryPath { get; init; }
        public string FileNameFormat { get; init; }
        public string FileExtension { get; init; }
        public int FilesLimit { get; init; }
    }
}