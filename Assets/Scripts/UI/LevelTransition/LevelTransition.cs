using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelTransition : MonoBehaviour
{
    GameManager gameManager;
    Image image;
    void Start()
    {
        gameManager = GameManager.instance;
        image = transform.Find("Circle").GetComponent<Image>();
        gameManager.switchLevel.AddListener(OnSwitchLevel);
    }

    void OnSwitchLevel()
    {
        image.transform.DOScale(0, 1).SetLoops(2, LoopType.Yoyo);
    }
}
