namespace MarkFlow.FileService;

public class FileService : IFileService
{
    public event Func<Task>? OnFileChanged;
    private readonly string _path = string.Empty;

    public FileService(string path)
    {
        _path = path;
    }

    public async Task<string> ReadFileAsync()
    {
        using var stream = File.OpenRead(_path);
        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }

    public void MonitorFile()
    {
        var directory = Path.GetDirectoryName(_path);
        var filename = Path.GetFileName(_path);

        var watcher = new FileSystemWatcher()
        {
            Path = directory,
            Filter = filename,
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName
        };

        watcher.Changed += async (sender, args) =>
        {
            try
            {
                await Task.Delay(1000);

                OnFileChanged?.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        };

        watcher.EnableRaisingEvents = true;
    }
}

