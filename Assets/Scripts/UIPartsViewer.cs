using Scripts.Services;
using Unity.VisualScripting;
using UnityEngine;

public class UIPartsViewer : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsToHide;
    [SerializeField] private GameObject _menu;
    [SerializeField] private float _startHideDelay;

    public static UIPartsViewer Instance { get; private set; }

    private void Start()
    {
        Instance ??= this;
        _menu.SetActive(true);
        AllServices.Container.GetSingleton<GameStateTransmiter>().StartGame.AddListener(() => _menu.SetActive(false));
        AllServices.Container.GetSingleton<GameStateTransmiter>().StartGame.AddListener(ShowHints);
    }

    private void HideHints()
    {
        foreach (var obj in _objectsToHide)
            obj.SetActive(false);
    }

    public void ShowHints()
    {
        foreach(var obj in _objectsToHide)
            obj.SetActive(true);
        Invoke(nameof(HideHints), _startHideDelay);
    }

    public void HideMenu()
    {
        _menu.SetActive(false);
    }
}
