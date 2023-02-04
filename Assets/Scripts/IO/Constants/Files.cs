using System.IO;

public static class Files
{
    public static readonly FileInfo GameSettings = new FileInfo(FilePaths.GetGameSettings);
}

public static class FilePaths
{
    public static readonly string GetGameSettings = Path.Combine(DirectoryPaths.GameFiles, $"{nameof(GameSettings)}.json");
}