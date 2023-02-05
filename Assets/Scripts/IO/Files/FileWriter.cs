using System;
using System.IO;
using System.Threading;
using UnityEngine;

public static class FileWriter
{
    private static readonly ReaderWriterLock _locker = new ReaderWriterLock();

    public static void Write(FileInfo file, string text)
    {
        try
        {
            _locker.AcquireWriterLock(int.MaxValue);
            File.WriteAllText(file.FullName, text);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
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
            
            if (!file.Exists)
            {
                File.WriteAllText(file.FullName, text + Environment.NewLine);
                return;
            }
            
            File.AppendAllText(file.FullName, text + Environment.NewLine);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
        finally
        {
            _locker.ReleaseWriterLock();
        }
    }
    
}