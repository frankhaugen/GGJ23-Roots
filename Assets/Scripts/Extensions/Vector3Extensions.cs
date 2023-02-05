using UnityEngine;

public static class Vector3Extensions
{
    public static Position ToPosition(this Vector3 vector3) => new Position() { X = vector3.x, Y = vector3.y };
}