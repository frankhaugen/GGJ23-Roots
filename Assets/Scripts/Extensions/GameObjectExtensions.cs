using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneExtensions
{
    public static string GetDirectoryName(this Scene scene)
    {
        var directoryName = Path.GetInvalidPathChars().Aggregate(scene.name.ToLower(), (current, invalidFileNameChar) => current.Replace(invalidFileNameChar, '_'));
        return directoryName;
    }
}
public static class GameObjectExtensions
{
    public static GameObjectInfo ToGameObjectInfo(this GameObject gameObject)
    {
        var info = new GameObjectInfo
        {
            Name = gameObject.name,
            Position = gameObject.transform.position.ToPosition(),
            Rotation = gameObject.transform.rotation.ToRotation()
        };
        return info;
    }
    
    public static void SetState(this GameObject gameObject, GameObjectInfo gameObjectInfo)
    {
        if (gameObjectInfo == null || gameObjectInfo.Name != gameObject.name)
        {
            Logger.LogError($"Could not set state for {gameObject.name}");
            return;
        }
        
        gameObject.transform.position = gameObjectInfo.Position.ToVector2();
        gameObject.transform.rotation = gameObjectInfo.Rotation.ToQuaternion();
        
        Logger.LogInfo($"Set state for {gameObject.name}");
        
    }
    
    public static string GetFilename(this GameObject gameObject)
    {
        var filename = Path.GetInvalidFileNameChars().Aggregate(gameObject.name.ToLower(), (current, invalidFileNameChar) => current.Replace(invalidFileNameChar, '_'));
        return filename;
    }
    
    public static FileInfo GetAutoSaveFile(this GameObject gameObject)
    {
        var filename = gameObject.GetFilename();
        var scenename = gameObject.scene.GetDirectoryName();
        var file = new FileInfo(Path.Combine(Directories.Autosaves.FullName, scenename, $"{filename}.json"));
        return file;
    }
}