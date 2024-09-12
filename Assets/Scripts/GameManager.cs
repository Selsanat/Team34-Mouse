using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UnityEvent scoreUpdated = new UnityEvent();
    public UnityEvent switchLevel = new UnityEvent();
    public UnityEvent Death = new UnityEvent();
    public UnityEvent Victory = new UnityEvent();

    public int score = 0;
    public int CurrentRoom = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
