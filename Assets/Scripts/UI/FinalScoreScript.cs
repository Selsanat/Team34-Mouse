using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScoreScript : MonoBehaviour
{
    TMPro.TextMeshProUGUI scoreText;
    GameManager gameManager;
    private void Start()
    {
        scoreText = this.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        gameManager = GameManager.instance;
    }
    public void UpdateScore()
    {
        scoreText.text = "Final Score: " + gameManager.score;
    }
}
