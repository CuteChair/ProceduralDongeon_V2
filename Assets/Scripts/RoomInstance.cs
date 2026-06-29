using UnityEngine;
using UnityEngine.InputSystem;

public class RoomInstance : MonoBehaviour
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
                if (tileConnector.TryGetComponent<DoorTileInstance>(out DoorTileInstance doorTileData))
                {
                    print($"{tileConnector.name}'s direction : {DirectionHelper.GetTileDirectionBasedOnRoomDirection(doorTileData.DefaultDirection, CurrentDirection)}");
                }
            }

            float currYRot = transform.localRotation.eulerAngles.y;

            print("Current y rotation : " + currYRot);

            float rotAmount = (currYRot + 90f) % 360;

            print("New rotation value : " + rotAmount);

            transform.rotation = Quaternion.Euler(0, rotAmount, 0); 
            
        }
    }

}
