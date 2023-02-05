using UnityEngine;

public class Position
{
    public float X { get; }
    public float Y { get; }

    public Position(float x, float y)
    {
        X = x;
        Y = y;
    }
    
    public Position(Vector2 vector2)
    {
        X = vector2.x;
        Y = vector2.y;
    }
}