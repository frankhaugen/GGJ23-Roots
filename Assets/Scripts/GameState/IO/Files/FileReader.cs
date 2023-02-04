using System.IO;
using UnityEngine;

public class FileReader : MonoBehaviour
{
    public byte[] Read(FileInfo file)
    {
        using var stream = file.OpenRead();
        var bytes = new byte[stream.Length];
        stream.Read(bytes, 0, (int)stream.Length);
        return bytes;
    }
}