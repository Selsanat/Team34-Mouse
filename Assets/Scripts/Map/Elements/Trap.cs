using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trap : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] bool trap = true;
    [SerializeField] GameObject movingPart;

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
                //Quaternion rotation = Quaternion.Euler(movingPart.transform.rotation.x, movingPart.transform.rotation.y, movingPart.transform.rotation.z);
                Vector3 rotation = new Vector3(movingPart.transform.rotation.x, movingPart.transform.rotation.y, 180);
                movingPart.transform.DORotate(rotation, 0.2f, RotateMode.LocalAxisAdd);
                movingPart.transform.DOPunchPosition(new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f)), 0.5f, 10, 1);
            }

        }
    }
}
