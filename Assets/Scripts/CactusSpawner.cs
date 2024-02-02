using System.Collections.Generic;
using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
    [SerializeField] private float _startSpawnDistance;

    [SerializeField] private GameObject _soloSpike;
    [SerializeField] private GameObject _duoSpikes;
    [SerializeField] private GameObject _trioSpikes;
    [SerializeField] private GameObject _flyingDummy;
    [SerializeField] private DinoSpeedChanger _speedChanger;
    [SerializeField, Range(0.3f, 1.5f)] private float _spawnAcceletationRate;

    private float _currentSpawnDistance => _startSpawnDistance * (1 + (_speedChanger.StartSpeed / _speedChanger.CurrentSpeed * _spawnAcceletationRate)); 

    private List<GameObject> _obstacles;

    public void CheckToSpawn(Vector3 lastPlatformToSpawnObstacles, float offset)
    {
        if (_obstacles == null || _obstacles.Count == 0)
            _obstacles = new List<GameObject> { SpawnRandomObstaclesAt(lastPlatformToSpawnObstacles.x) };
        SpawnWhileInPlatBounds(lastPlatformToSpawnObstacles, offset);
    }

    private void SpawnWhileInPlatBounds(Vector3 lastPlatformToSpawnObstacles, float offset)
    {
        while (_obstacles[^1].transform.position.x - _currentSpawnDistance >= (lastPlatformToSpawnObstacles.x + (offset / 2)))
            _obstacles.Add(SpawnRandomObstaclesAt(_obstacles[^1].transform.position.x - _currentSpawnDistance));
    }

    private GameObject SpawnRandomObstaclesAt(float xAxis)
    {
        GameObject prefabToSpawn;
        int chance = Random.Range(1, 12);
        if (chance <= 5) prefabToSpawn = _soloSpike;
        else if (chance <= 8) prefabToSpawn = _duoSpikes;
        else if (chance < 11) prefabToSpawn = _trioSpikes;
        else prefabToSpawn = _flyingDummy;
        return Instantiate(prefabToSpawn, new Vector3(xAxis, prefabToSpawn.transform.position.y, prefabToSpawn.transform.position.z), Quaternion.identity);
    }
}
