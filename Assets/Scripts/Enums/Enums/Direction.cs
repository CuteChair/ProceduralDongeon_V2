using UnityEngine;

public enum Direction
{
    NORTH,
    EAST,
    SOUTH,
    WEST
}

public static class DirectionHelper
{
    public static Direction GetOppositeDirection(Direction currentDirection)
    {
        int opp = ((int)currentDirection + 2) % 4;

        return (Direction)opp;
    }

    public static Direction GetTileDirectionBasedOnRoomDirection(Direction tileDefaultDir, Direction currentRoomDir) 
    {
        if (currentRoomDir == Direction.NORTH)
        {
            return tileDefaultDir;
        }

        Direction newDirection = (Direction)(((int)tileDefaultDir + (int)currentRoomDir) % 4);

        return newDirection;

    }

    public static float GetRandomQuaternionEuler()
    {
        int newDirection = Random.Range(0, 4);

        switch (newDirection)
        {
            case 0: return 0f;
            case 1: return 90f;
            case 2: return 180f;
            case 3: return 270f;
        }

        return 0f;
    }
}
