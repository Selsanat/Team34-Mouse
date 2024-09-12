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
    }
    private void UpdateScore()
    {
        scoreText.text = "Score: " + gameManager.score;
    }
}
