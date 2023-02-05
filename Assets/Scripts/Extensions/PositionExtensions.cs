using UnityEngine;

public static class PositionExtensions
{
    public static Vector2 ToVector2(this Position position) => new Vector2(position.X, position.Y);
}
public static class RotationExtensions
{
    public static Quaternion ToQuaternion(this Rotation rotation) => Quaternion.Euler(rotation.X, rotation.Y, rotation.Z);
}