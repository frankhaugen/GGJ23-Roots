
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeGame
{
    [RuntimeInitializeOnLoadMethod]
    public static void InitializeFiles()
    {
        
        InitializeDirectories();
        InitializeGameSettings();
        
        Logger.LogInfo("Game Initialized");
    }
    
    public static void InitializeDirectories()
    {
        if (!Directories.GameFiles.Exists) Directories.GameFiles.Create();
        if (!Directories.Saves.Exists) Directories.Saves.Create();
        if (!Directories.Autosaves.Exists) Directories.Autosaves.Create();
        if (!Directories.Screenshots.Exists) Directories.Screenshots.Create();
        if (!Directories.Logs.Exists) Directories.Logs.Create();
        if (!Directories.PlayerSettings.Exists) Directories.PlayerSettings.Create();
    }

    public static void InitializeGameSettings()
    {
        if (!Files.GameSettings.Exists)
        {
            var defaultGameSettings = new GameSettings()
            {
                Difficulty = Difficulty.Normal,
                GameName = "Roots of Destiny"
            };
            var gameSettings = SerializationUtility.Serialize(defaultGameSettings);
            FileManager.Write(Files.GameSettings, gameSettings);
        }
    }
}