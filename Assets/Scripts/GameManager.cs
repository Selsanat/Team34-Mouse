using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UnityEvent scoreUpdated = new UnityEvent();
    public int score = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
