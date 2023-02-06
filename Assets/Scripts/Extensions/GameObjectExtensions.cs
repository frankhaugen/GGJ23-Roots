using System;
using System.IO;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

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
    
    public static StringBuilder GetDebugInformation(this GameObject gameObject)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Name: {gameObject.name}");
        stringBuilder.AppendLine($"Tag: {gameObject.tag}");
        stringBuilder.AppendLine($"Layer: {gameObject.layer}");
        stringBuilder.AppendLine($"Active: {gameObject.activeSelf}");
        stringBuilder.AppendLine($"Active in Hierarchy: {gameObject.activeInHierarchy}");
        stringBuilder.AppendLine($"Static: {gameObject.isStatic}");
        stringBuilder.AppendLine($"Position: {gameObject.transform.position}"); 
        stringBuilder.AppendLine($"Rotation: {gameObject.transform.rotation}");
        stringBuilder.AppendLine($"Scale: {gameObject.transform.localScale}");

        foreach (var component in gameObject.GetComponents<Component>())
        {
            // indent the component fields for readability by adding four spaces
            stringBuilder.AppendLine($"Component: {component.name}");
            stringBuilder.AppendLine("    "  + $"Type: {component.GetType()}");
            stringBuilder.AppendLine("    "  + $"Tag: {component.tag}");
            stringBuilder.AppendLine("    "  + $"Layer: {component.gameObject.layer}");
        }

        return stringBuilder;
    }
    
       public static void LogDebugInformation(this GameObject gameObject)
        {
            Logger.LogInfo(gameObject.GetDebugInformation().ToString());
        }
}

public static class ObjectExtensions
{
    
    public static void LogDebugInformation<T>(this T obj) where T : Object
    {
        Logger.LogInfo(obj.GetDebugInformation().ToString());
    }
    
    public static StringBuilder GetDebugInformation<T>(this T obj) where T : Object
    {
        if (obj != null && obj is GameObject gameObject)
        {
            return gameObject.GetDebugInformation();
        }
        
        var stringBuilder = new StringBuilder();

        try
        {
            stringBuilder.AppendLine($"Name: {obj.name}");
            stringBuilder.AppendLine($"Type: {obj.GetType()}");
        }
        catch (Exception e)
        {
            Logger.LogError(e);
        }
        
        return stringBuilder;
    }
    
    public static string GetFilename(this Object obj)
    {
        var filename = Path.GetInvalidFileNameChars().Aggregate(obj.name.ToLower(), (current, invalidFileNameChar) => current.Replace(invalidFileNameChar, '_'));
        return filename;
    }
    
    public static FileInfo GetAutoSaveFile(this Object obj)
    {
        var filename = obj.GetFilename();
        var file = new FileInfo(Path.Combine(Directories.Autosaves.FullName, $"{filename}.json"));
        return file;
    }
}