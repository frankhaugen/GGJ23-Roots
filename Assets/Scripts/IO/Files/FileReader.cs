using System;
using System.IO;
using UnityEngine;

public class FileReader
{
    public static string Read(FileInfo file)
    {
        try
        {
            return File.ReadAllText(file.FullName);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return null;
        }
    }
}