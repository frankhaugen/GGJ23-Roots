using System.IO;

public static class FileManager
{

    public static void Write(FileInfo file, string text)
    { 
        FileWriter.Write(file, text);
    }

    public static void Write<T>(FileInfo file, T obj)
    {
        var text = SerializationUtility.Serialize(obj);
        FileWriter.Write(file, text);
    }

    public static string Read(FileInfo file)
    {
        return FileReader.Read(file);
    }

    public static T Read<T>(FileInfo file)
    {
        var text = Read(file);
        return SerializationUtility.Deserialize<T>(text);
    }
}