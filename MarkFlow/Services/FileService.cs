namespace MarkFlow.FileService;

public class FileService : IFileService
{
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
}

