using System.IO;
using UnityEngine;

public static class DirectoryPaths
{
    public static readonly string AssetFiles = Application.dataPath;
    
    public static readonly string GameFiles = Path.Combine(new DirectoryInfo(AssetFiles).Parent.FullName, DirectoryNames.GameFiles);

    public static readonly string Saves = Path.Combine(GameFiles, DirectoryNames.Saves);

    public static readonly string Autosaves = Path.Combine(Saves, DirectoryNames.Autosaves);

    public static readonly string Screenshots = Path.Combine(GameFiles, DirectoryNames.Screenshots);

    public static readonly string Logs = Path.Combine(GameFiles, DirectoryNames.Logs);

    public static readonly string PlayerSettings = Path.Combine(GameFiles, DirectoryNames.PlayerSettings);
}