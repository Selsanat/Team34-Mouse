using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] int scoreGain = 1;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.score += scoreGain;
            gameManager.scoreUpdated.Invoke();
            gameManager.ateCheese.Invoke();
            Destroy(this.gameObject);   
        }
    }
}
