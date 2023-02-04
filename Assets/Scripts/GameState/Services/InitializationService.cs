public class InitializationService
{
    public void InitializeDirectories()
    {
        if (!Directories.GameFiles.Exists) Directories.GameFiles.Create();
        if (!Directories.Saves.Exists) Directories.Saves.Create();
        if (!Directories.Autosaves.Exists) Directories.Autosaves.Create();
        if (!Directories.Screenshots.Exists) Directories.Screenshots.Create();
        if (!Directories.Logs.Exists) Directories.Logs.Create();
        if (!Directories.PlayerSettings.Exists) Directories.PlayerSettings.Create();
    }

    public void InitializeGameSettings()
    {
        if (!Files.GameSettings.Exists)
        {
            var gameSettings = SerializationUtility.Serialize(new GameSettings());
            FileManager.Write(Files.GameSettings, gameSettings);
        }
    }
}