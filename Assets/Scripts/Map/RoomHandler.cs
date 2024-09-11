using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    [SerializeField] bool SpawnRoomOnStart = false;
    private GameManager _gameManager;
    [SerializeField] List<GameObject> _rooms;
    GameObject _currentRoom;
    RealDoorObject _refDoor;
    [SerializeField] Transform _RoomOrigin;
    GameObject RefPlayer;

    // Start is called before the first frame update
    void Start()
    {
        RefPlayer = GameObject.FindGameObjectWithTag("Player");
        _gameManager = GameManager.instance;
        _gameManager.switchLevel.AddListener(SwitchRooms);

        if (SpawnRoomOnStart)
        {
            SwitchRooms();
        } else
        {
            LinkToDoor();
        }
    }

    void SwitchRooms()
    {
        _gameManager.CurrentRoom++;
        print(_gameManager.CurrentRoom);
        if(_rooms.Count <= 0 ||_gameManager.CurrentRoom >= 9) {
            // Start victory sequence
            print("Victory");
        } else {
            // Switch Rooms
            RefPlayer.SetActive(false);
            // unload room
            if (_currentRoom) {
                Object.Destroy(_currentRoom);
                _currentRoom = null;
            }
            if (CheckRooms() == true) {
                SpawnRoom();
                // Subscribe to new door
                LinkToDoor();
            }
        }
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

    void SpawnRoom()
    {
        // get random number
        var WhichRoom = Random.Range(0, _rooms.Count);
        // load random room from _rooms[WhichRoom]
        _currentRoom = Instantiate(_rooms[WhichRoom], _RoomOrigin);
        _rooms.Remove(_rooms[WhichRoom]);
        // spawn player at correct position
        StartCoroutine(DelayedPlayerSpawn());
    }

    IEnumerator DelayedPlayerSpawn()
    {
        yield return new WaitForEndOfFrame();
        PlayerSpawn();
    }

    void PlayerSpawn()
    {
        var temp = _currentRoom.transform;
        bool found = false;
        // find spawnPoint
        for (int i = 0; i < temp.childCount; i++)
        {
            print(temp.GetChild(i).name);
            if (temp.GetChild(i).gameObject.tag == "Spawn")
            {
                RefPlayer.transform.position = temp.GetChild(i).gameObject.transform.position;
                print("found spawn point !");
                found = true;
                RefPlayer.SetActive(true);
                return;
            }
        }
        if (!found)
        {
            Debug.LogError("No Spawn point!");
            Application.Quit();
        }
    }

    bool LinkToDoor()
    {
        // first clear door if preexists
        if (_refDoor)
        {
            _refDoor = null;
        }
        // then find door and try to link
        _refDoor = FindObjectOfType<RealDoorObject>();
        if (_refDoor)
        {
            //_gameManager.switchLevel.RemoveListener(SwitchRooms);
            //_gameManager.switchLevel.AddListener(SwitchRooms);
            return true;
        }
        print("Door not found !");
        Debug.LogWarning("Door not found !");
        return false;
    }
}
