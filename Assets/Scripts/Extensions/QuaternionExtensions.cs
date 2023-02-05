using UnityEngine;

public static class QuaternionExtensions
{
    public static Rotation ToRotation(this Quaternion quaternion)
    {
        return new Rotation() { X = quaternion.x, Y = quaternion.y, Z = quaternion.z };
    }
}