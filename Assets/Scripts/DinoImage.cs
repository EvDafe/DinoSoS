using Scripts.Services;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DinoImage : MonoBehaviour, IService
{
    [SerializeField] private Image _dino;
    [SerializeField] private Sprite _defaultDino;
    [SerializeField] private Sprite _wowDino;
    [SerializeField] private Sprite _sadDino;
    [SerializeField] private Sprite _cakeDino;
    [SerializeField] private float _emotionDelay = 2f;

    private void Start()
    {
        AllServices.Container.RegisterSingleton(this);
        _dino ??= GetComponent<Image>();
    }

    private void OnEnable() =>
        _dino.sprite = _defaultDino;

    public void MakeDinoEmot(bool happy)
    {
        if (happy)
            StartCoroutine(nameof(MakeDinoHappy));
        else
            StartCoroutine(nameof(MakeDinoSad));
    }

    private IEnumerator MakeDinoHappy() =>
         MakeDinoEmotion(true);

    private IEnumerator MakeDinoSad() =>
        MakeDinoEmotion(false);

    private IEnumerator MakeDinoEmotion(bool happy)
    {
        _dino.sprite = happy ? _wowDino :  _sadDino;
        yield return new WaitForSeconds(_emotionDelay);
        _dino.sprite = _defaultDino;
    }

    public void MakeDinoCake() =>
        StartCoroutine(nameof(MakeDinoDragCake));

    private IEnumerator MakeDinoDragCake()
    {
        _dino.sprite = _cakeDino;
        yield return new WaitForSeconds(_emotionDelay);
        _dino.sprite = _defaultDino;
    }
}
