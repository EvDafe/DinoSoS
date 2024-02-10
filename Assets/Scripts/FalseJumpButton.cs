using Scripts.Services;

public class FalseJumpButton : FalseInteractiveButton, IService
{
    private void Awake() =>
        AllServices.Container.RegisterSingleton(this);

    public void ChangeButtonState(bool toPressed) =>
        _button.sprite = toPressed ? _pressedButton : _defaultButton;
}
