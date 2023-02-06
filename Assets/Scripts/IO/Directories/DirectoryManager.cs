using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DirectoryManager
{
    public static string GetRootDirectoryPath() => Path.Combine(Application.dataPath, "GameFiles");

    public static DirectoryInfo GetRootDirectory() => new(GetRootDirectoryPath());

    public static IEnumerable<DirectoryInfo> GetDirectories(DirectoryInfo directory) => directory.GetDirectories("", SearchOption.AllDirectories);

    public static IEnumerable<FileInfo> GetFiles() => GetRootDirectory().GetFiles("", SearchOption.AllDirectories);
}