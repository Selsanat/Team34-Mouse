using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottles : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.touchedBottle.Invoke();
        }
    }
}
