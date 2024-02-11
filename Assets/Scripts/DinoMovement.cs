using Scripts.Services;
using UnityEngine;
using UnityEngine.UIElements;

public class DinoMovement : MonoBehaviour, IService
{
    [SerializeField] private DinoAnimationController _animationController;
    [SerializeField] private DinoSpeedChanger _dinoSpeedChanger;

    [SerializeField] private UIButtonInfo _crouchButton;

    private bool _isJumping = false;
    private bool _isRunning = false;

    private void Start()
    {
        AllServices.Container.GetSingleton<GameStateTransmiter>().StartGame.AddListener(StartRunning);
        AllServices.Container.GetSingleton<GameStateTransmiter>().Died.AddListener(() => Destroy(this));
        AllServices.Container.RegisterSingleton(this);
    }

    private void StartRunning()
    {
        _isJumping = false;
        _isRunning = true;
        _animationController.SetIsRunning(true);
    }

    private void FixedUpdate()
    {
        if (_isRunning) 
            transform.position += Vector3.left * _dinoSpeedChanger.CurrentSpeed * Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (_isRunning == false) return;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            Jump();

        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.DownArrow) || Input.GetMouseButton((int)MouseButton.RightMouse) || Input.GetKey(KeyCode.S))
            SetCrouchungFlag(true);

        else if(!_crouchButton.isDown)
            SetCrouchungFlag(false);

        else
            SetCrouchungFlag(true);
    }

    public void Jump()
    {
        if (!_isJumping)
            _animationController.Jump();
    }

    public void SetCrouchungFlag(bool isCrouching)
    {
        _animationController.SetIsCrouching(isCrouching);
        AllServices.Container.GetSingleton<FalseSneakButton>().ChangeButtonState(isCrouching);
    }

    private void ChangeIsJumpingFlag(bool isJumping)
    {
        _isJumping = isJumping;
        AllServices.Container.GetSingleton<FalseJumpButton>().ChangeButtonState(isJumping);
    }

    public void SetIsJumpingToFalse() =>
        ChangeIsJumpingFlag(false);

    public void SetIsJumpingToTrue() =>
        ChangeIsJumpingFlag(true);
}
