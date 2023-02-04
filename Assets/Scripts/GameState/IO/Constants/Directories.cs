using System.IO;

public static class Directories
{
    public static readonly DirectoryInfo GameFiles = new DirectoryInfo(DirectoryPaths.GameFiles);

    public static readonly DirectoryInfo Saves = new DirectoryInfo(DirectoryPaths.Saves);

    public static readonly DirectoryInfo Autosaves = new DirectoryInfo(DirectoryPaths.Autosaves);

    public static readonly DirectoryInfo Screenshots = new DirectoryInfo(DirectoryPaths.Screenshots);

    public static readonly DirectoryInfo Logs = new DirectoryInfo(DirectoryPaths.Logs);

    public static readonly DirectoryInfo PlayerSettings = new DirectoryInfo(DirectoryPaths.PlayerSettings);
}