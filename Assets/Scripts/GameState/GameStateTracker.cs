using System;
using System.Collections.Generic;
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
    }