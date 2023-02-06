using UnityEngine;

public static class QuaternionExtensions
{
    public static Rotation ToRotation(this Quaternion quaternion)
    {
        return new Rotation() { X = quaternion.x, Y = quaternion.y, Z = quaternion.z };
    }
    
    public  static Vector2 ToVector2(this Quaternion quaternion)
    {
        return new Vector2(quaternion.x, quaternion.y);
    }
}