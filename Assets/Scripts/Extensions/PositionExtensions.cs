using UnityEngine;

public static class PositionExtensions
{
    public static Vector2 ToVector2(this Position position) => new Vector2(position.X, position.Y);
}