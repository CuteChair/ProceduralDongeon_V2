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
}
