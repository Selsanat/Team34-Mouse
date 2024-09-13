using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class AlertIcon : MonoBehaviour
{
    [SerializeField] Sprite _greenIcon;
    [SerializeField] Sprite _redIcon;
    [SerializeField] Sprite _orangeIcon;

    Image _image;
    TMPro.TextMeshProUGUI _text;
    CanvasGroup _canvasGroup;
    GameManager _gameManager;
    Tween tweenScale;
    Tween tweenOpacity;
    public void Start()
    {
        _gameManager = GameManager.instance;
        _image = transform.Find("Icon").GetComponent<Image>();
        _canvasGroup  = GetComponent<CanvasGroup>();
        _text = transform.Find("Noise").GetComponent<TMPro.TextMeshProUGUI>();
        _gameManager.alertLevelChanged.AddListener(UpdateIcon);
        _gameManager.resetAlertLevel.AddListener(ResetIcons);
    }

    public void ResetIcons()
    {
        StartCoroutine(ResetIconsDelayed());
    }
    IEnumerator ResetIconsDelayed()
    {
        yield return new WaitForSeconds(1f);
        tweenScale.Kill();
        tweenOpacity.Kill();
        _canvasGroup.DOFade(0, 1f);
        _image.sprite = _greenIcon;
        _text.color = Color.green;
    }
    public void UpdateIcon()
    {
        switch (_gameManager.alertLevel)
        {
            case 3:
                _canvasGroup.DOFade(1, 1f);
                tweenOpacity = _image.DOFade(0.25f, 1f).SetLoops(-1, LoopType.Yoyo);
                break;
            case 6:
                tweenOpacity.Kill();
                _canvasGroup.DOFade(0, 1f).OnComplete(() =>
                {
                    _image.sprite = _orangeIcon;
                    _text.color = new Color(1, 0.5f, 0);
                    _canvasGroup.DOFade(1, 1f).OnComplete(() =>
                    {
                        tweenScale = _image.transform.DOPunchScale(new Vector3(-0.1f, -0.1f, -0.1f), 2f, 2, 0).SetLoops(-1, LoopType.Yoyo);
                        tweenOpacity = _image.DOFade(0.25f, 1f).SetLoops(-1, LoopType.Yoyo);
                    });
                });
                break;
            case 9:
                tweenScale.Kill();
                tweenOpacity.Kill();
                _canvasGroup.DOFade(0, 1f).OnComplete(() =>
                {
                    _image.sprite = _redIcon;
                    _text.color = Color.red;
                    _canvasGroup.DOFade(1, 1f);
                    tweenScale = _image.transform.DOPunchScale(new Vector3(-0.2f, -0.2f, -0.2f), 2f, 2, 0).SetLoops(-1, LoopType.Yoyo);
                    tweenOpacity = _image.DOFade(0.5f, 1f).SetLoops(-1, LoopType.Yoyo);
                });
                break;
        }
    }
}
