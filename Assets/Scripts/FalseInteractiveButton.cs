using UnityEngine;
using UnityEngine.UI;

public class FalseInteractiveButton : MonoBehaviour
{
    [SerializeField] protected Sprite _defaultButton;
    [SerializeField] protected Sprite _pressedButton;
    [SerializeField] protected Image _button;
    [SerializeField] private UIButtonInfo _buttonToFollow;

    private void OnValidate() =>
        _button ??= GetComponent<Image>();
}
