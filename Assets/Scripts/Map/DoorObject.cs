using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class DoorObject : MonoBehaviour
{
    public UnityEvent _switchLevelEvent = new UnityEvent();

    public void ClearListeners()
    {
        _switchLevelEvent.RemoveAllListeners();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _switchLevelEvent.Invoke();
        }
    }
}
