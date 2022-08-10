using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] _cubes;
    //[SerializeField] MaxSpawnEnum _maxSpawn;

    Transform[] _spawnPointArray;

    private void Awake()
    {
        _spawnPointArray = GetComponentsInChildren<Transform>();
    }
    void Start()
    {
        SpawnCube();
    }

    void SpawnCube()
    {
        for (int i = 1; i < _spawnPointArray.Length; i++)
        {
            GameObject sPoint = _spawnPointArray[i].gameObject;
            sPoint.transform.position = new Vector3(sPoint.transform.position.x + 1.2f * Random.Range(0, 4), sPoint.transform.position.y + 0.5f, sPoint.transform.position.z);
            Instantiate(_cubes[Random.Range(0, GameManager.Instance.MaxSpawnEnum)], sPoint.transform.position, Quaternion.identity);
        }
    }
}
