using UnityEngine;

public class HintsHider : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsToHide;
    [SerializeField] private float _startHideDelay;

    public static HintsHider Instance { get; private set; }

    private void Start() =>
        Instance ??= this;

    private void Hide()
    {
        foreach (var obj in _objectsToHide)
            obj.SetActive(false);
    }

    public void Show()
    {
        foreach(var obj in _objectsToHide)
            obj.SetActive(true);
        Invoke(nameof(Hide), _startHideDelay);
    }
}
