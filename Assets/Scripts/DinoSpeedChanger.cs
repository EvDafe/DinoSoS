using UnityEngine;

public class DinoSpeedChanger : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedChangeCooldown;
    [SerializeField] private float _speedChangeRate;
    [SerializeField] private float _speedChangeStartDelay;

    [SerializeField] public float CurrentSpeed { get ; private set; }

    public float StartSpeed => _startSpeed;

    private void Awake()
    {
        CurrentSpeed = _startSpeed;
        InvokeRepeating(nameof(UpdateSpeed), _speedChangeStartDelay, _speedChangeCooldown);
    }

    private void UpdateSpeed()
    {
        if (CurrentSpeed == _maxSpeed) return;

        CurrentSpeed += _speedChangeRate;
        if (CurrentSpeed > _maxSpeed) CurrentSpeed = _maxSpeed;
    }
}
