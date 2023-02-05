using System.IO;
using System.Threading;

public static class FileWriter
{
    private static readonly ReaderWriterLock _locker = new ReaderWriterLock();

    public static void Write(FileInfo file, byte[] bytes)
    {
        try
        {
            _locker.AcquireWriterLock(int.MaxValue);
            using var stream = file.OpenWrite();
            stream.Write(bytes, 0, bytes.Length);
        }
        finally
        {
            _locker.ReleaseWriterLock();
        }
    }
    
    public static void Write(FileInfo file, string text)
    {
        try
        {
            _locker.AcquireWriterLock(int.MaxValue);

            using var fileCreation = file.CreateText();
            fileCreation.Write(text);
            // File.WriteAllText(file.FullName, text);
        }
        finally
        {
            _locker.ReleaseWriterLock();
        }
    }
    
    public static void Append(FileInfo file, byte[] bytes)
    {
        try
        {
            _locker.AcquireWriterLock(int.MaxValue);
            using var stream = file.Open(FileMode.Append, FileAccess.Write);
            stream.Write(bytes, 0, bytes.Length);
        }
        finally
        {
            _locker.ReleaseWriterLock();
        }
    }
    
    public static void Append(FileInfo file, string text)
    {
        try
        {
            _locker.AcquireWriterLock(int.MaxValue);
            File.AppendAllText(file.FullName, text);
        }
        finally
        {
            _locker.ReleaseWriterLock();
        }
    }
    
}