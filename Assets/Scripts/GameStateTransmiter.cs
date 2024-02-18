using Scripts.Services;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameStateTransmiter : MonoBehaviour, IService
{
    [SerializeField] private Animator _camera;

    public UnityEvent StartGame;
    public UnityEvent Died;

    private bool _alive = true;

    private void Awake() =>
        AllServices.Container.RegisterSingleton(this);

    public void OnGameStarted()
    {
        _camera.SetTrigger("ToGame");
        StartGame.Invoke();

        Destroy(GetComponent<Button>().gameObject);
    }

    public void OnDinoDied()
    {
        if (_alive)
        {
            _alive = false;
            Died.Invoke();
            AllServices.Container.GetSingleton<Sounds>().PlayDieSound();
        }
    }

}
