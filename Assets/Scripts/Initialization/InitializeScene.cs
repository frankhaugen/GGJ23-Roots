using System;
using System.Linq;
using UnityEngine;

public class InitializeScene : MonoBehaviour
{
    void Awake()
    {
        var sceneAutosaveDirectory = Directories.Autosaves.CreateSubdirectory(gameObject.scene.GetDirectoryName());
        if (!sceneAutosaveDirectory.Exists) sceneAutosaveDirectory.Create();
    }

    void Start()
    {
        try
        {
            InitializeGameobjects();
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    void OnDestroy()
    {
        try
        {
            UninitializeGameobjects();
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    void InitializeGameobjects()
    {
        var gameObjects = FindObjectsOfType<GameObject>().Where(x => x.TryGetComponent<GameObjectStateSaver>(out var stateSaver) && stateSaver.enabled);
        foreach (var gameObject in gameObjects)
        {
            GameStateTracker.LoadState(gameObject);
        }
    }

    void UninitializeGameobjects()
    {
        var gameObjects = FindObjectsOfType<GameObject>().Where(x => x.TryGetComponent<GameObjectStateSaver>(out var stateSaver) && stateSaver.enabled);
        foreach (var gameObject in gameObjects)
        {
            GameStateTracker.SaveGameObjectState(gameObject);
        }
        
        GameStateTracker.WriteStatesToDisk();
    }
}