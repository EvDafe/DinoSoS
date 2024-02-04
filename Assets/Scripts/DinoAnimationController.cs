using Scripts.Services;
using UnityEngine;

public class DinoAnimationController : MonoBehaviour
{
    private const string IsRunning = nameof(IsRunning);
    private const string IsCrouch = nameof(IsCrouch);
    private const string IsOnlyRunning = nameof(IsOnlyRunning);
    private const string JumpTrigger = "Jump";
    private const string DiedTrigger = "Died";

    [SerializeField] private Animator _animator;

    private void Start() =>
        AllServices.Container.GetSingleton<GameStateTransmiter>().Died.AddListener(SetToDied);

    public void SetIsRunning(bool isRunning) =>
        _animator.SetBool(IsRunning, isRunning);

    public void SetIsCrouching(bool isCrouch) =>
        _animator.SetBool(IsCrouch, isCrouch);

    public void Jump() =>
        _animator.SetTrigger(JumpTrigger);

    public void SetOnlyRunning() =>
         _animator.SetTrigger(IsOnlyRunning);

    public void SetToDied()
    {
        SetIsRunning(false);
        _animator.SetTrigger(DiedTrigger);
    }
}
