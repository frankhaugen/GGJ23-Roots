using System.IO;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    private readonly FileReader _reader = new FileReader();
    private readonly FileWriter _writer = new FileWriter();

    public void Write(FileInfo file, byte[] bytes) => _writer.Write(file, bytes);

    public byte[] Read(FileInfo file) => _reader.Read(file);

    public void Move(FileInfo file, string newName) => file.MoveTo(newName);

    public void Rename(FileInfo file, string newName) => file.MoveTo(newName);

    public void Create(FileInfo file) => file.Create();

    public void Delete(FileInfo file) => file.Delete();

    public void Copy(FileInfo file, string newName) => file.CopyTo(newName);
}
