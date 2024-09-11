using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trap : MonoBehaviour
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
            gameManager.hitTrap.Invoke();
        }
    }
}
