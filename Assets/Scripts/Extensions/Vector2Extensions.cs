using UnityEngine;

public static class Vector2Extensions
{
    public static Position ToPosition(this Vector2 vector2) => new Position(vector2.x, vector2.y);
}