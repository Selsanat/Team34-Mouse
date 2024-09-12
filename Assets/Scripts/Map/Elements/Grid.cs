using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class Grid : MonoBehaviour
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
            gameManager.touchedGrid.Invoke();
        }
    }
}
