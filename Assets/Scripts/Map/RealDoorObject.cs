using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class RealDoorObject : MonoBehaviour
{
    private GameManager _gameManager;
    private bool _enabled = true;
    SoundManager soundManager;
    private void Start()
    {
        _gameManager = GameManager.instance;
        soundManager = SoundManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && _enabled)
        {
            _gameManager.switchLevel.Invoke();
            soundManager.PlayClip("Win");
            _gameManager.ResolveLevel.Invoke();
            Destroy(this);
        }
    }
}
