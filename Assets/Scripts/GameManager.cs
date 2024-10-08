using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UnityEvent scoreUpdated = new UnityEvent();

    public UnityEvent touchedBottle = new UnityEvent();
    public UnityEvent ateCheese = new UnityEvent();
    public UnityEvent hitTrap = new UnityEvent();
    public UnityEvent touchedGrid = new UnityEvent();
    public UnityEvent fellDown = new UnityEvent();


    public UnityEvent gamePaused = new UnityEvent();
    public UnityEvent alertLevelChanged = new UnityEvent();
    public UnityEvent resetAlertLevel = new UnityEvent();

    public UnityEvent switchLevel = new UnityEvent();
    public UnityEvent ResolveLevel = new UnityEvent();
    public UnityEvent Death = new UnityEvent();
    public UnityEvent Victory = new UnityEvent();

    public int score = 0;
    public int alertLevel = 0;
    public bool spawning = true;
    public int CurrentRoom = 0;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ResetValues()
    {
        score = 0;
        alertLevel = 0;
        CurrentRoom = 0;
        scoreUpdated.Invoke();
    }
}
