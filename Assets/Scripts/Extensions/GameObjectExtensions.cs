using UnityEngine;

public static class GameObjectExtensions
{
    public static PlayerInfo ToPlayerInfo(this GameObject gameObject)
    {
        var playerInfo = new PlayerInfo
        {
            Name = gameObject.name,
            Position = gameObject.transform.position.ToPosition()
        };
        return playerInfo;
    }
}