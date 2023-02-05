using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InitializeScene : MonoBehaviour
{
    private IEnumerable<GameObject> TrackedGameObjects() => FindObjectsOfType<GameObject>().Where(x => x.TryGetComponent<GameObjectStateSaver>(out var stateSaver) && stateSaver.enabled);

    private void Awake()
    {
        var sceneAutosaveDirectory = Directories.Autosaves.CreateSubdirectory(gameObject.scene.GetDirectoryName());
        if (!sceneAutosaveDirectory.Exists) sceneAutosaveDirectory.Create();
        InitializeGameobjects();
    }

    private void InitializeGameobjects()
    {
        var gameObjects = TrackedGameObjects();
        foreach (var gameObject in gameObjects)
        {
            GameStateTracker.LoadState(gameObject);
        }
    }

    private void OnDestroy()
    {
        var gameObjects = TrackedGameObjects();
        foreach (var gameObject in gameObjects)
        {
            GameStateTracker.SaveGameObjectState(gameObject);
        }
        
        GameStateTracker.WriteStatesToDisk();
        
    }
}