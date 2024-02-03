using Scripts.Services;
using UnityEngine;

public class DinoSpeedChanger : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedChangeCooldown;
    [SerializeField] private float _speedChangeRate;

    [SerializeField] public float CurrentSpeed { get ; private set; }

    private float _currentCooldown;
    private bool _isGameExist;

    public float StartSpeed => _startSpeed;

    private void Start()
    {
        CurrentSpeed = _startSpeed;
        _isGameExist = false;
        AllServices.Container.GetSingleton<GameStateTransmiter>().StartGame.AddListener(() => { _isGameExist = true; _currentCooldown = _speedChangeCooldown; });
        AllServices.Container.GetSingleton<GameStateTransmiter>().Died.AddListener(() => _isGameExist = false);
    }

    private void Update()
    {
        if (_isGameExist && _currentCooldown <= 0)
        {
            _currentCooldown = _speedChangeCooldown;
            if (CurrentSpeed >= _maxSpeed) return;

            CurrentSpeed += _speedChangeRate;
            if (CurrentSpeed > _maxSpeed) CurrentSpeed = _maxSpeed;
        }
        else if (_isGameExist)
        {
            _currentCooldown -= Time.deltaTime;
        }
    }
}
