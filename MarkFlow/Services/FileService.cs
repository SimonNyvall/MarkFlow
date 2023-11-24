namespace MarkFlow.FileService;

public class FileService : IFileService
{
    public async Task<string> ReadFileAsync(string path)
    {
        using var stream = File.OpenRead(path);
        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }
}

