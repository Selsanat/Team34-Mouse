using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    [SerializeField] bool SpawnRoomOnStart = false;
    [SerializeField] List<GameObject> _rooms;
    List<GameObject> _Copyrooms;
    [SerializeField] GameObject _IntroRoom;
    [SerializeField] GameObject _FinalRoom;
    [SerializeField] Transform _RoomOrigin;
    enum RoomTypes
    {
        Intro,
        Classic,
        Final,
    }

    // Refs (unchanging)
    private GameManager _gameManager;
    GameObject RefPlayer;

    // Refs (changing)
    GameObject _currentRoom;
    RealDoorObject _refDoor;

    // Parameters
    [SerializeField] int MaxAmountRoom = 9;

    // Vars
    bool IsFinalSwitch = false;



    // Start is called before the first frame update
    void Start()
    {
        RefPlayer = GameObject.FindGameObjectWithTag("Player");
        _gameManager = GameManager.instance;
        _gameManager.switchLevel.AddListener(SwitchRooms);
        _Copyrooms = new List<GameObject>(_rooms);

        if (SpawnRoomOnStart)
        {
            SwitchRooms();
        } else
        {
            LinkToDoor();
        }
    }

    public void Restart()
    {
        //print("Restart");
        _rooms = new List<GameObject>(_Copyrooms);
        IsFinalSwitch = false;
        _gameManager.CurrentRoom = 0;
        SwitchRooms();
    }

    void SwitchRooms()
    {
        // Ending Sequence, debug to prevent issues, the real ending sequence shouldn't need to start from here
        if(IsFinalSwitch)
        {
            Debug.Log("Victory");
            _gameManager.Victory.Invoke();
            return;
        }
        RefPlayer.GetComponent<CharacterController>().enabled = false;
        //print("switching room !");
        _gameManager.CurrentRoom++;
        //print(_gameManager.CurrentRoom);
        // unload room
        if (_currentRoom)
        {
            Object.Destroy(_currentRoom);
            _currentRoom = null;
        }
        //Final Room
        if (_rooms.Count <= 0 ||_gameManager.CurrentRoom >= MaxAmountRoom) 
        {
            //print("Final Room");
            IsFinalSwitch = true;
            SpawnRoom(RoomTypes.Final);

        } else 
        {
            // Intro room
            if (_gameManager.CurrentRoom == 1)
            {
                print("Intro");
                SpawnRoom(RoomTypes.Intro);

            }
            // Regular Room
            else if (CheckRooms() == true)
            {
                SpawnRoom(RoomTypes.Classic);
            }
        }
        // Subscribe to new door
        LinkToDoor();
    }

    bool CheckRooms()
    {
        if ( _rooms == null )
        {
            //print("No room loaded !");
            Debug.LogWarning("No room loaded !");
            return false;
        }
        return true;
    }

    void SpawnRoom(RoomTypes Type)
    {
        switch (Type)
        {
            case RoomTypes.Intro:
                _currentRoom = Instantiate(_IntroRoom, _RoomOrigin);
                break;

            case RoomTypes.Classic:
                // get random number
                var WhichRoom = Random.Range(0, _rooms.Count);
                // load random room from _rooms[WhichRoom]
                _currentRoom = Instantiate(_rooms[WhichRoom], _RoomOrigin);
                _rooms.Remove(_rooms[WhichRoom]);
                break;

            case RoomTypes.Final:
                _currentRoom = Instantiate(_FinalRoom, _RoomOrigin);
                break;

            default:
                break;

        }
        StartCoroutine(DelayedPlayerSpawn());
    }

    IEnumerator DelayedPlayerSpawn()
    {
        yield return new WaitForSeconds(1);
        PlayerSpawn();
    }

    void PlayerSpawn()
    {
        var temp = _currentRoom.transform;
        bool found = false;
        // find spawnPoint
        for (int i = 0; i < temp.childCount; i++)
        {
            //print(temp.GetChild(i).name);
            if (temp.GetChild(i).gameObject.tag == "Spawn")
            {
                RefPlayer.transform.position = temp.GetChild(i).gameObject.transform.position;
                //print("found spawn point !");
                found = true;
                RefPlayer.GetComponent<CharacterController>().enabled = true;
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
            return true;
        }
        //print("Door not found !");
        Debug.LogWarning("Door not found !");
        return false;
    }
}
