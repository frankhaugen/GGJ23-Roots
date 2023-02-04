using System.IO;
using UnityEngine;

public class FileWriter : MonoBehaviour
{
    public void Write(FileInfo file, byte[] bytes)
    {
        using var stream = file.OpenWrite();
        stream.Write(bytes, 0, bytes.Length);
    }
}