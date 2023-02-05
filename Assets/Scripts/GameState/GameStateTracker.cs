using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

    public static class GameStateTracker
    {
        private static readonly Dictionary<string, PlayerInfo> _players = new Dictionary<string, PlayerInfo>(new InvariantCaselessStringComparer());
        
        public static void SaveGameObjectState(GameObject gameObject)
        {
            var playerInfo = gameObject.ToPlayerInfo();
            
            if (_players.ContainsKey(playerInfo.Name))
            {
                _players[playerInfo.Name] = playerInfo;
            }
            else
            {
                _players.Add(playerInfo.Name, playerInfo);
            }
        }
        
        public static void SaveState(string name)
        {
            var gameObject = GameObject.Find(name);
            
            if (gameObject == null)
            {
                Logger.LogError($"Could not find game object with name {name}");
                return;
            }
            
            var playerInfo = gameObject.ToPlayerInfo();
            var filename = Path.GetInvalidFileNameChars().Aggregate(name.ToLower(), (current, invalidFileNameChar) => current.Replace(invalidFileNameChar, '_'));
            var file = new FileInfo(Path.Combine(Directories.Autosaves.FullName, $"{filename}.json"));
            FileManager.Write(file, playerInfo);
        }
    }