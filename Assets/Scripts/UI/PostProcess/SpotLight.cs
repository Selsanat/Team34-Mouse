using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpotLight : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.instance;
        
        gameManager.alertLevelChanged.AddListener(() =>
        {
            Light light = GetComponent<Light>();
            int alertLevel = gameManager.alertLevel;
            if (alertLevel <= 3)
            {
                DOTween.To(() => light.range, x => light.range = x, 1f+alertLevel, 0.3f);

            }
            else if(alertLevel <= 6)
            {
                DOTween.To(() => light.color, x => light.color = x, Color.Lerp(Color.white, new Color(1, 1, 0, 1), (alertLevel - 3) / 3f), 0.3f);
            }
            else if(alertLevel <= 9)
            {
                DOTween.To(() => light.color, x => light.color = x, Color.Lerp(new Color(1, 1, 0, 1), new Color(1, 0, 0, 1), (alertLevel - 6) / 3f), 0.3f);
            }
        });
    }
}
