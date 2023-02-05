using UnityEngine;

public static class PlayerInfoExtensions
{
    public static GameObject ToGameObject(this PlayerInfo playerInfo)
    {
        var gameObject = new GameObject(playerInfo.Name);
        gameObject.transform.position = playerInfo.Position.ToVector2();
        return gameObject;
    }
}