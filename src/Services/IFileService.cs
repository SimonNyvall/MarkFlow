namespace MarkFlow.FileService;

public interface IFileService
{
    event Func<Task>? OnFileChanged;

    Task<string> ReadFileAsync();

    void MonitorFile();
}
