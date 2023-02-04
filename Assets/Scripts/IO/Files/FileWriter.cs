using System.IO;
using System.Threading;

public static class FileWriter
{
    private static ReaderWriterLock _locker = new ReaderWriterLock();

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
    
}