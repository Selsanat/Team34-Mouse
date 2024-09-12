using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    GameManager _gameManager;
    bool gamePaused = false;
    private void Start()
    {
        _gameManager = GameManager.instance;

        _gameManager.gamePaused.AddListener(PauseGame);
    }

    public void PauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused ?  0:1;
        transform.GetChild(0).gameObject.SetActive(gamePaused);
    }


    public void restartGame()
    {
        PauseGame();
        print("TO BE IMPLEMENTED");
    }
}
