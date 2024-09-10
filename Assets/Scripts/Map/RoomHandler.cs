using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    [SerializeField] GameObject[] _rooms;
    GameObject _currentRoom;
    DoorObject _refDoor;

    // Start is called before the first frame update
    void Start()
    {
        LinkToDoor();
    }


    bool LinkToDoor()
    {
        // first clear door if preexists
        if (_refDoor)
        {
            _refDoor.ClearListeners();
            _refDoor = null;
        }
        // then find door and try to link
        _refDoor = FindObjectOfType<DoorObject>();
        if (_refDoor)
        {
            _refDoor._switchLevelEvent.AddListener(SwitchRooms);
            return true;
        }
        print("Door not found !");
        Debug.LogWarning("Door not found !");
        return false;
    }

    bool CheckRooms()
    {
        if ( _rooms == null )
        {
            print("No room loaded !");
            Debug.LogWarning("No room loaded !");
            return false;
        }
        return true;
    }

    void SwitchRooms()
    {
        // Start fade to black
        // unload room
        Object.Destroy(_currentRoom);
        _currentRoom = null;
        // get random number
        var WhichRoom = Random.Range(0, _rooms.Length);
        // load random room from _rooms[WhichRoom]
        _currentRoom = Instantiate(_rooms[WhichRoom]);
        // spawn player at correct position
        GameObject TempPlayer = GameObject.FindGameObjectWithTag("Player");
        TempPlayer.transform.parent = GameObject.FindGameObjectWithTag("Spawn").transform;
        // fade to color
        // Subscribe to new door
        LinkToDoor();
    }
}
