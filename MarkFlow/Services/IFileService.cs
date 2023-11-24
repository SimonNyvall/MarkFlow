namespace MarkFlow.FileService;

public interface IFileService
{
  Task<string> ReadFileAsync(string path);
}
