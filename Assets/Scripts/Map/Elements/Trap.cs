using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trap : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] bool trap = true;
    private void Start()
    {
        gameManager = GameManager.instance;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(trap)
            {
                gameManager.hitTrap.Invoke();
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }

        }
    }
}
