using UnityEngine;

public static class Vector2Extensions
{
    public static Position ToPosition(this Vector2 vector2) => new Position() { X = vector2.x, Y = vector2.y };
}