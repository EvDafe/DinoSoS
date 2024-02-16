using Scripts.Services;
using UnityEngine;

public class Sounds : MonoBehaviour, IService
{
    [SerializeField] private AudioSource _source;
    [Space]
    [SerializeField] private AudioClip _jump;
    [SerializeField] private AudioClip _die;
    [SerializeField] private AudioClip _bought;
    [SerializeField] private AudioClip _notBought;
    [SerializeField] private AudioClip _selected;

    private void Start() =>
        AllServices.Container.RegisterSingleton(this);

    private void OnValidate() =>
        _source ??= GetComponent<AudioSource>();

    private void PlaySound(AudioClip clipToPlay) =>
        _source.PlayOneShot(clipToPlay);

    public void PlayJumpSound() => PlaySound(_jump);
    public void PlayDieSound() => PlaySound(_die);
    public void PlayBoughtSound() => PlaySound(_bought);
    public void PlayNotBoughtSound() => PlaySound(_notBought);
    public void PlaySelectedSound() => PlaySound(_selected);

}
