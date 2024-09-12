using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class RealDoorObject : MonoBehaviour
{
    private GameManager _gameManager;
    private bool _enabled = true;
    private void Start()
    {
        _gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && _enabled)
        {
            print("collideddadzdzzdzddzzdzdzd");
            _gameManager.switchLevel.Invoke();
            Destroy(this);
        }
    }
}
