using Scripts.Services;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameStateTransmiter : MonoBehaviour, IService
{
    [SerializeField] private Animator _camera;

    public UnityEvent StartGame;
    public UnityEvent Died;

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
        Died.Invoke();
    }

}
