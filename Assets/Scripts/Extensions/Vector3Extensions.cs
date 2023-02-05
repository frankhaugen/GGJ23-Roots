using UnityEngine;

public static class Vector3Extensions
{
    public static Position ToPosition(this Vector3 vector3) => new Position(vector3.x, vector3.y);
}