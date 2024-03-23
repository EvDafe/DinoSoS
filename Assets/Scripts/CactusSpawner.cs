using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CactusSpawner : MonoBehaviour
{
    [SerializeField] private float _startSpawnDistance;

    [SerializeField] private GameObject _soloSpike;
    [SerializeField] private GameObject _duoSpikes;
    [SerializeField] private GameObject _trioSpikes;
    [SerializeField] private GameObject _flyingDummy;
    [SerializeField] private DinoSpeedChanger _speedChanger;
    [SerializeField, Range(0.3f, 5f)] private float _spawnAcceletationRate;
    [SerializeField] private float _maxSpawnDistance;

    private float _currentSpawnDistance => _calculatedSpawnDistance >= _maxSpawnDistance ? _maxSpawnDistance : _calculatedSpawnDistance;
    private float _calculatedSpawnDistance => _startSpawnDistance * (_speedChanger.CurrentSpeed / _speedChanger.StartSpeed / _spawnAcceletationRate);

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
        if (chance <= 6) prefabToSpawn = _soloSpike;
        else if (chance <= 9) prefabToSpawn = _duoSpikes;
        else if (chance < 11) prefabToSpawn = _trioSpikes;
        else prefabToSpawn = _flyingDummy;
        return Instantiate(prefabToSpawn, new Vector3(xAxis, prefabToSpawn.transform.position.y, prefabToSpawn.transform.position.z), Quaternion.identity);
    }

    public void DeleteExtraObstacles(float xPlatformToDeleteOn)
    {
        if (_obstacles == null) return;
        foreach(var obstacle in _obstacles) 
            if (obstacle != null && obstacle.transform.position.x > xPlatformToDeleteOn)
                Destroy(obstacle);

        _obstacles = _obstacles.Where(x => x != null).ToList();
    }
}
