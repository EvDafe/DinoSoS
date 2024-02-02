using UnityEngine;

public class HintsHider : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsToHide;
    [SerializeField] private float _startHideDelay;

    private void Start() =>
        Invoke(nameof(Hide), _startHideDelay);

    private void Hide()
    {
        foreach (var obj in _objectsToHide)
            obj.SetActive(false);
    }
}
