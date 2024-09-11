using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlertManager : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.instance;
        gameManager.alertLevelChanged.AddListener(() =>
        {
            transform.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Alert Level: " + gameManager.alertLevel;
        });
        gameManager.hitTrap.AddListener(() =>
        {
            gameManager.alertLevel += 3;
            gameManager.alertLevelChanged.Invoke();
        });
        gameManager.touchedBottle.AddListener(() =>
        {
            gameManager.alertLevel++;
            gameManager.alertLevelChanged.Invoke();
        });
        gameManager.touchedGrid.AddListener(() =>
        {
            gameManager.alertLevel++;
            gameManager.alertLevelChanged.Invoke();
        });
        gameManager.fellDown.AddListener(() =>
        {   
            gameManager.alertLevel++;
            gameManager.alertLevelChanged.Invoke();
        });

    }

}
