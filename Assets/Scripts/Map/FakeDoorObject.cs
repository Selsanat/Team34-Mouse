using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeDoorObject : MonoBehaviour
{
    private GameManager _gameManager;
    private bool _enabled = true;
    private void Start()
    {
        _gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _enabled)
        {
            _gameManager.resetAlertLevel.Invoke();
            _gameManager.Death.Invoke();
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
    }
}
