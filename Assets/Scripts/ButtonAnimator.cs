using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator _button;

    private const string _isPressed = "IsPressed"; 

    private void OnValidate() =>
        _button ??= GetComponent<Animator>();

    public void UpButton() =>
        _button.SetBool(_isPressed, true);

    public void DownButton() =>
        _button.SetBool(_isPressed, false);

    public void OnPointerEnter(PointerEventData pointerEventData) =>
        UpButton();

    public void OnPointerExit(PointerEventData pointerEventData) =>
        DownButton();
}
