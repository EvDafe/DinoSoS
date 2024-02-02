using UnityEngine;
using UnityEngine.UIElements;

public class DinoMovement : MonoBehaviour
{
    [SerializeField] private DinoAnimationController _animationController;
    [SerializeField] private DinoSpeedChanger _dinoSpeedChanger;

    [SerializeField] private UIButtonInfo _crouchButton;

    private bool _isJumping = false;

    private void Start()
    {
        _isJumping = false; 
        _animationController.SetIsRunning(true);
    }

    private void FixedUpdate() =>
        transform.position += Vector3.left * _dinoSpeedChanger.CurrentSpeed * Time.fixedDeltaTime;

    private void Update()
    {
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

    public void SetCrouchungFlag(bool isCrouching) =>
        _animationController.SetIsCrouching(isCrouching);
    
    private void ChangeIsJumpingFlag(bool isJumping) =>
        _isJumping = isJumping;

    public void ChangeIsJumpingToFalse() =>
        ChangeIsJumpingFlag(false);

    public void ChangeIsJumpingToTrue() =>
        ChangeIsJumpingFlag(true);
}
