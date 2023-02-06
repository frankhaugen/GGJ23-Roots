using System;
using System.Collections.Generic;
using UnityEngine;

    public static class GameStateTracker
    {
        private static readonly Dictionary<string, GameObject> _gameObjects = new(new InvariantCaselessStringComparer());
        
        public static void SaveGameObjectState(GameObject gameObject)
        {
            if (_gameObjects.ContainsKey(gameObject.name))
            {
                _gameObjects[gameObject.name] = gameObject;
            }
            else
            {
                _gameObjects.Add(gameObject.name, gameObject);
            }
        }

        public static void WriteStateToDisk(string name)
        {
            if (_gameObjects.ContainsKey(name))
            {
                var gameObject = _gameObjects[name];
                FileManager.Write(gameObject.GetAutoSaveFile(), gameObject.ToGameObjectInfo());
            }
        }
        
        public static bool TryLoadStateFromDiskDirect(GameObject gameObject)
        {
            var saveFile = gameObject.GetAutoSaveFile();
            
            if (saveFile.Exists)
            {
                var gameObjectInfo = FileManager.Read<GameObjectInfo>(saveFile);

                if (gameObjectInfo != null)
                {
                    gameObject.SetState(gameObjectInfo);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static void WriteStatesToDisk()
        {
            if (_gameObjects.Count>0)
            {
                foreach (var obj in _gameObjects.Values)
                {
                    try
                    {
                        FileManager.Write(obj.GetAutoSaveFile(), obj.ToGameObjectInfo());
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                }
            }
        }
        
        public static void LoadState(GameObject gameObject)
        {
            var saveFile = gameObject.GetAutoSaveFile();
            
            if (saveFile.Exists)
            {
                var gameObjectInfo = FileManager.Read<GameObjectInfo>(saveFile);

                if (gameObjectInfo != null)
                {
                    gameObject.SetState(gameObjectInfo);
                }
            }
        }
    }