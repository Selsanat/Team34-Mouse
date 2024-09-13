using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
            foreach (Transform child in transform)
            {
                if (Random.Range(0, 2) == 1)    
                {
                    child.DOPunchScale(new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f)), 0.5f, 10, 1);
                }
                else
                {
                    child.DOPunchPosition(new Vector3(Random.Range(-0.3f, 0.5f), Random.Range(-0.3f, 0.5f), Random.Range(-0.3f, 0.5f)), 0.5f, 10, 1);
                }

            }
            gameManager.touchedBottle.Invoke();
        }
    }
}
