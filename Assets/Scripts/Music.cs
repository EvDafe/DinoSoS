using Scripts.Infrastructure;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource[] _songs;

    private void Start() =>
        EnableRandomSong();

    private void EnableRandomSong()
    {
        foreach (var song in _songs) song.Stop();
        int currentID = (Bootstrapper.LastSongID < 0 || Bootstrapper.LastSongID > _songs.Length - 1) ? GetRandomID() : GetRandomID(Bootstrapper.LastSongID);
        _songs[currentID].Play();
        Bootstrapper.LastSongID = currentID;
    }

    private int GetRandomID(int exceptionID = -1)
    {
        int currentID = Random.Range(0, _songs.Length);
        while (currentID == exceptionID)
            currentID = Random.Range(0, _songs.Length);
        return currentID;   
    }
}