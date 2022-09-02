using UnityEngine;

public enum Direction
{
    Down,
    Left,
    Right,
    Up
}

public class DirectionUtil
{
    public static Vector2 ToVector(Direction direction)
    {
        switch(direction)
        {
            case Direction.Down:
                return Vector2.down;
            case Direction.Left:
                return Vector2.left;
            case Direction.Right:
                return Vector2.right;
            case Direction.Up:
                return Vector2.up;
        }
        return Vector2.left;
    }
}
