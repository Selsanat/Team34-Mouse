using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    TMPro.TextMeshProUGUI scoreText;
    GameManager gameManager;
    private void Start()
    {
        scoreText = this.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        gameManager = GameManager.instance;
        UpdateScore();
        GameManager.instance.scoreUpdated.AddListener(UpdateScore);
        gameManager.switchLevel.AddListener(() =>
        {
            StartCoroutine(addScore());
        });
    }

    IEnumerator addScore()
    {
        yield return new WaitForSeconds(2);
        gameManager.score += 2;
        UpdateScore();
    }
    private void UpdateScore()
    {
        scoreText.text = ""+gameManager.score;
    }
}
