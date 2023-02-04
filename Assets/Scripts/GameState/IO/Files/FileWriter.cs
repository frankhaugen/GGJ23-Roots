using System.IO;

public static class FileWriter
{
    public static void Write(FileInfo file, byte[] bytes)
    {
        using var stream = file.OpenWrite();
        stream.Write(bytes, 0, bytes.Length);
    }
}