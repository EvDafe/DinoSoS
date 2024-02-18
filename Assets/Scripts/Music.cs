using Scripts.Infrastructure;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource[] _songs;
    [SerializeField] private Toggle _toggle;
    private int _currentID;

    private void Start() =>
        EnableRandomSong();

    private void EnableRandomSong()
    {
        foreach (var song in _songs) song.Stop();
        _currentID = (Bootstrapper.LastSongID < 0 || Bootstrapper.LastSongID > _songs.Length - 1) ? GetRandomID() : GetRandomID(Bootstrapper.LastSongID);
        _songs[_currentID].volume = _toggle.isOn ? 1 : 0;
        _songs[_currentID].Play(); 
        Bootstrapper.LastSongID = _currentID;
    }

    private int GetRandomID(int exceptionID = -1)
    {
        int currentID = Random.Range(0, _songs.Length);
        while (currentID == exceptionID)
            currentID = Random.Range(0, _songs.Length);
        return currentID;   
    }

    public void UpdateVolume() =>
        _songs[_currentID].volume = _toggle.isOn ? 1 : 0;
}