using UnityEngine;
using UnityEngine.InputSystem;

public class RoomData : MonoBehaviour
{

    /// <summary>
    /// Script that contains data about rooms : 
    /// 
    /// - Which TileConnectors this room possesses
    /// - The current orientation of the room
    /// 
    /// This script should be used to get intel rather then do stuff
    /// </summary>

    public Direction DefaultDirection;

    public Direction CurrentDirection;

    public GameObject[] TileConnectorsArray;

    private void Awake()
    {
        CurrentDirection = DefaultDirection;
    }

    public void OnDebugPressed(InputAction.CallbackContext ctx)
    {
        if (ctx.canceled)
        {
            Direction tempDir = (Direction)(((int)CurrentDirection + 1) % 4);
            CurrentDirection = tempDir;

            print("New Room Direction : " + CurrentDirection);

            foreach (GameObject tileConnector in TileConnectorsArray)
            {
                if (tileConnector.TryGetComponent<DoorTileData>(out DoorTileData doorTileData))
                {
                    print($"{tileConnector.name}'s direction : {DirectionHelper.GetTileDirectionBasedOnRoomDirection(doorTileData.DefaultDirection, CurrentDirection)}");
                }
            }

            Vector3 newRotation = new Vector3(0, 90f, 0);

            transform.rotation = Quaternion.Euler(newRotation);
            
        }
    }

}
