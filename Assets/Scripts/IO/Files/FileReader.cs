using System.IO;

public class FileReader
{
    public static byte[] Read(FileInfo file)
    {
        using var stream = file.OpenRead();
        var bytes = new byte[stream.Length];
        stream.Read(bytes, 0, (int)stream.Length);
        return bytes;
    }
}