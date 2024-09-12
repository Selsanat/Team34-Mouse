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
        gameManager.ResolveLevel.AddListener(() => StartCoroutine(OnResolveLevel()));
        gameManager = GameManager.instance;
        gameManager.Death.AddListener(() =>
        {
            gameManager.switchLevel.Invoke();
            StartCoroutine(HideTransition());
        }
        );
    }

    IEnumerator HideTransition()
    {
        yield return new WaitForSeconds(8f);
        image.transform.DOScale(15, 1);
    }
    void OnSwitchLevel()
    {
        if (gameManager.CurrentRoom<10)
        image.transform.DOScale(0, 1);
    }
    IEnumerator OnResolveLevel()
    {
        if (gameManager.CurrentRoom < 10)
        {
            yield return new WaitForSeconds(3f);
            image.transform.DOScale(15, 1);
        }
    }
}
