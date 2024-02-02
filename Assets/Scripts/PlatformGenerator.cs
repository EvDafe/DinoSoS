using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    //The code at this project is just shitpost to make it as fast as I able to do
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject[] _platforms;
    [SerializeField] private CactusSpawner _spawner;

    private int _firstPlatformIndex;
    private float _platfromsOffset;

    private void Awake()
    {
        GetFirstPlatform();
        _platfromsOffset = -(_platforms[0].transform.position.x - _platforms[1].transform.position.x);

        //for (int i = 2; i < _platforms.Length; i++)
            //_spawner.CheckToSpawn(_platforms[i].transform.position, _platfromsOffset);
    }

    public void TeleportPlatform()
    {
        _platforms[_firstPlatformIndex].transform.position = new Vector3(
                _platforms[_firstPlatformIndex].transform.position.x + _platforms.Length * _platfromsOffset,
                _platforms[_firstPlatformIndex].transform.position.y,
                _platforms[_firstPlatformIndex].transform.position.z);

        GetFirstPlatform();
        _spawner.CheckToSpawn(_platforms[GetPrewPlatformIndex(_firstPlatformIndex, _platforms.Length)].transform.position, _platfromsOffset);
        Debug.Log(string.Format("Last plat pos is: {0}", _platforms[GetPrewPlatformIndex(_firstPlatformIndex, _platforms.Length)].transform.position));
    }

    private void GetFirstPlatform()
    {
        _firstPlatformIndex = 0;
        for (int i = 1; i < _platforms.Length; i++)
            if (_platforms[i].transform.position.x > _platforms[_firstPlatformIndex].transform.position.x)
                _firstPlatformIndex = i;
    }

    private int GetNextPlatformIndex(int index) =>
        index == _platforms.Length - 1 ? 0 : index + 1;

    private int GetPrewPlatformIndex(int index, int length) =>
        index == 0 ? length - 1 : index - 1;

    private void Update()
    {
        if (_player.transform.position.x < _platforms[GetNextPlatformIndex(_firstPlatformIndex)].transform.position.x)
            TeleportPlatform();
    }
}
