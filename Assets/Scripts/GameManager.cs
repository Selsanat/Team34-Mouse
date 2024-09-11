using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
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


    public int score = 0;
    public int alertLevel = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
