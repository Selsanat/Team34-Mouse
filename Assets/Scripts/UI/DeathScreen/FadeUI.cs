using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using Unity.VisualScripting;
public class FadeUI : MonoBehaviour
{
    public UnityEvent StartFade = new UnityEvent();
    public UnityEvent TransitionFade = new UnityEvent();
    public UnityEvent EndFade = new UnityEvent();

    GameManager gameManager;


    [SerializeField] private CanvasGroup fadingCanvasGroup;
    [SerializeField] float FadingInTime = 2;
    [SerializeField] float DurationFlat = 3;
    [SerializeField] float FadingOutTime = 2;
    [SerializeField] float InitialDelay = 0;
    [SerializeField] private bool isFaded = false;
    public void Fade()
    {
        isFaded = !isFaded;
        if(isFaded)
        {
            fadingCanvasGroup.DOFade(1, FadingInTime);
        } else
        {
            fadingCanvasGroup.DOFade(0, FadingOutTime);
        }
    }

    public void FadeInAndOut()
    {
        StartCoroutine(FadeRoutine());
    }

    IEnumerator FadeRoutine()
    {
        yield return new WaitForSeconds(3);
        if(InitialDelay > 0)
            yield return new WaitForSeconds(InitialDelay);
        StartFade.Invoke();
        Fade();
        yield return new WaitForSeconds(FadingInTime);
        yield return new WaitForSeconds(DurationFlat);

        Fade();
        TransitionFade.Invoke();
        yield return new WaitForSeconds(FadingOutTime);
        EndFade.Invoke();
        print("d");
        yield return null;


    }
}
