using Scripts.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _song;
    [SerializeField] private Toggle _toggle;

    private void Start()
    {
        _song = Bootstrapper.Instance.gameObject.GetComponent<AudioSource>();
        _toggle.isOn = _song.volume == 1 ? true : false;
    }

    public void UpdateVolume() =>
        _song.volume = _toggle.isOn ? 1 : 0;
}