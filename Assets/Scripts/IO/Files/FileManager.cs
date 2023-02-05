using System.IO;
using System.Text;
using UnityEngine;

public static class FileManager
{
    public static void Write(FileInfo file, byte[] bytes) => FileWriter.Write(file, bytes);

    public static void Write(FileInfo file, string text)
    {
        var bytes = Encoding.UTF8.GetBytes(text);
        FileWriter.Write(file, bytes);
    }

    public static void Write(FileInfo file, GameObject obj)
    {
        var text = JsonUtility.ToJson(obj, true);
        var bytes = Encoding.UTF8.GetBytes(text);
        FileWriter.Write(file, bytes);
    }

    public static void Write<T>(FileInfo file, T obj)
    {
        var text = SerializationUtility.Serialize(obj);
        var bytes = Encoding.UTF8.GetBytes(text);
        FileWriter.Write(file, bytes);
    }

    public static byte[] Read(FileInfo file) => FileReader.Read(file);

    public static string ReadText(FileInfo file)
    {
        var bytes = FileReader.Read(file);
        return Encoding.UTF8.GetString(bytes);
    }

    public static GameObject ReadGameObject(FileInfo file)
    {
        var text = ReadText(file);
        return JsonUtility.FromJson<GameObject>(text);
    }
    
    public static T Read<T>(FileInfo file)
    {
        var text = ReadText(file);
        return SerializationUtility.Deserialize<T>(text);
    }

    public static void Move(FileInfo file, string newName) => file.MoveTo(newName);

    public static void Rename(FileInfo file, string newName) => file.MoveTo(newName);

    public static void Create(FileInfo file) => file.Create();

    public static void Delete(FileInfo file) => file.Delete();

    public static void Copy(FileInfo file, string newName) => file.CopyTo(newName);
}