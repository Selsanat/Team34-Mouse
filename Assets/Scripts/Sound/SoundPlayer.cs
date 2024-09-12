using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundPlayer : MonoBehaviour
{
    SoundManager soundManager;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = SoundManager.instance;
        gameManager = GameManager.instance;

        gameManager.ateCheese.AddListener(()=>
        {
            soundManager.PlayClip("ateCheese");
        });
        gameManager.touchedBottle.AddListener(() =>
        {
            soundManager.PlayClip("Bottle");
        });
        gameManager.scoreUpdated.AddListener(() =>
        {
            soundManager.PlayClip("scoreUp");
        });
        gameManager.hitTrap.AddListener(() =>
        {
            soundManager.PlayClip("Trap");
            soundManager.PlayRandomClip("Squeak");
        });
        gameManager.touchedGrid.AddListener(() =>
        {
            soundManager.PlayClip("Grid");
        });
        gameManager.fellDown.AddListener(() =>
        {
            soundManager.PlayRandomClip("Squeak");
            soundManager.PlayClip("Fell");
        });
        gameManager.Death.AddListener(() =>
        {
            soundManager.PlayClip("DeathScreen");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
