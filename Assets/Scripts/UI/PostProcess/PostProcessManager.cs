using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;

public class PostProcessManager : MonoBehaviour
{
    GameManager  gameManager;
    Tween tween;
    private void Start()
    {
        gameManager = GameManager.instance;
        gameManager.hitTrap.AddListener(() =>
        {
            Volume volume = transform.Find("Damaged").GetComponent<UnityEngine.Rendering.Volume>();
            volume.profile.TryGet(out UnityEngine.Rendering.Universal.Vignette Vignette);
            int alertLevel = gameManager.alertLevel;
            if (tween == null || !tween.IsPlaying()) tween = DOTween.To(() => Vignette.intensity.value, x => Vignette.intensity.value = x, 0.333f, 0.3f).SetLoops(2, LoopType.Yoyo);

        });
    }


}
