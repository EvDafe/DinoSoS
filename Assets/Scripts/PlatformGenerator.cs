using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject[] _platfroms;
    private int _firstPlatformIndex;
    private float _platfromsOffset;

    private void Awake()
    {
        GetFirstPlatform();
        _platfromsOffset = -(_platfroms[0].transform.position.x - _platfroms[1].transform.position.x);
    }

    public void TeleportPlatform()
    {
        Debug.Log(_platfromsOffset);
        _platfroms[_firstPlatformIndex].transform.position = new Vector3(
                _platfroms[_firstPlatformIndex].transform.position.x + _platfroms.Length * _platfromsOffset,
                _platfroms[_firstPlatformIndex].transform.position.y,
                _platfroms[_firstPlatformIndex].transform.position.z);

        GetFirstPlatform();
    }

    private void GetFirstPlatform()
    {
        _firstPlatformIndex = 0;
        for (int i = 1; i < _platfroms.Length; i++)
            if (_platfroms[i].transform.position.x > _platfroms[_firstPlatformIndex].transform.position.x)
                _firstPlatformIndex = i;
    }

    private int GetNextPlatformIndex(int index)
    {
        if (index == _platfroms.Length - 1) return 0;
        else return index + 1;
    }

    private void Update()
    {
        if (_player.transform.position.x < _platfroms[GetNextPlatformIndex(_firstPlatformIndex)].transform.position.x)
            TeleportPlatform();
    }
}
