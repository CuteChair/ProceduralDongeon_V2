using System;
using UnityEngine;

public class DoorTileInstance : MonoBehaviour
{
    /// <summary>
    /// Script that holds information about : 
    /// 
    /// - Where the connection between rooms will be at
    /// - Where a new door will need to be instanciated
    /// - Which direction each connection tiles have
    /// 
    /// This script should be used as gather intel rather than doing stuff
    /// 
    /// </summary>
    /// 

    [Tooltip("Cointains the default direction of a connection tile based on the parent's room default direction")]

    public Direction DefaultDirection;

    public Transform ConnectionTileSnapPoint;

}
