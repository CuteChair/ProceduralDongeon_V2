using NUnit.Framework;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
public class GeneratingProcess : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _availableStartingRooms;

    [SerializeField]
    private GameObject[] _availableRooms;

    [SerializeField]
    private List<RoomInstance> _generatedRoomRefs = new List<RoomInstance>();

    private float _generatedRoomCounts => _generatedRoomRefs.Count;

    public GenerationPocessState CurrentGenerationState { get; private set; }


    private GameObject _currentAnchorObject;
    private DoorTileInstance _currentAnchorRef;

    private void Awake()
    {
        StartCoroutine(GeneratingCoroutine(5f));
    }
    private void GenerateStartingRoom()
    {
        CurrentGenerationState = GenerationPocessState.GENERATING_STARTING_ROOM;
       
        if (_generatedRoomRefs.Count == 0)
        {
            float rotationAmout = DirectionHelper.GetRandomQuaternionEuler();

            GameObject newRoom = Instantiate(_availableStartingRooms[0], Vector3.zero, Quaternion.Euler(0f, rotationAmout, 0f));

            if (newRoom.TryGetComponent<RoomInstance>(out RoomInstance roomInstanceRef))
            {
                _generatedRoomRefs.Add(roomInstanceRef);     
            }    
        }
    }

    private void FindNewAnchorPoint()
    {
        CurrentGenerationState = GenerationPocessState.FINDING_NEXT_ANCHOR_POINT;

        RoomInstance newRoomInstance = _generatedRoomRefs[(int)RandomnessHelper.GetRandomFromList(0f, _generatedRoomCounts)];

        GameObject[] newCandidatesTiles = newRoomInstance.TileConnectorsArray;

        GameObject selectedTileObject = newCandidatesTiles[(int)RandomnessHelper.GetRandomFromList(0f, newCandidatesTiles.Length)];

        print($"Selected Tile : {selectedTileObject.name}");

        if (selectedTileObject.TryGetComponent<DoorTileInstance>(out DoorTileInstance tileInstanceRef))
        {

            _currentAnchorObject = selectedTileObject;
            _currentAnchorRef = tileInstanceRef;

        }
    }

    private void FindNextRoomCandidate(GameObject tileObject, DoorTileInstance tileInstanceRef)
    {
        
    }

    private void GenerateNewRoom()
    {
        
    }

    private IEnumerator GeneratingCoroutine(float stepIntervals)
    {

        GenerateStartingRoom();

        yield return new WaitForSeconds(stepIntervals);

        FindNewAnchorPoint();

        yield return new WaitForSeconds(stepIntervals);

        FindNextRoomCandidate(_currentAnchorObject, _currentAnchorRef);
    }
}

public enum GenerationPocessState
{
    GENERATING_STARTING_ROOM,               //Happens only once 

    //--------------------------------------------------------

    FINDING_NEXT_ANCHOR_POINT,              //Finding next connexion point 
    SELECTING_NEXT_ROOM_CANDIDATE,          //Selecting new room to place at connexion point
    MAPPING_NEW_ROOM_PLACEMENT,             //Mental map of rooms, verifying if room can theorically be placed there
    PLACING_ROOM,                           //Physically creating new room

    //---------------------------------------------------------

    GENERATION_COMPLETE,
    GENERATION_FAILED
}
public static class RandomnessHelper
{
    public static float GetRandomFromList(float min, float max)
    {
        float selected = Random.Range(min, max);

        return selected;
    }
}
