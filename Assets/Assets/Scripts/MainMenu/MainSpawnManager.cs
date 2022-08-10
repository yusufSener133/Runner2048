using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] _cubes;
    [SerializeField] float _minSpeed = 10, _maxSpeed = 100;
    [SerializeField] GameObject[] _effect;
    public GameObject[] Effect { get { return _effect; } }

    Transform[] _spawnPoints;
    void Awake()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
    }
    void Start()
    {
        StartCoroutine(Spawner(
            _cubes[Random.Range(0, _cubes.Length)],
            _spawnPoints[Random.Range(1, _spawnPoints.Length)]));
    }
    IEnumerator Spawner(GameObject cube, Transform cubePos)
    {
        GameObject go = Instantiate(cube, cubePos.position, Quaternion.identity);
        go.AddComponent<DestroyCube>();
        Destroy(go, 3f);
        Rigidbody goRigidbody = go.GetComponent<Rigidbody>();
        goRigidbody.useGravity = false;
        goRigidbody.constraints = RigidbodyConstraints.None;
        goRigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        switch (cubePos.gameObject.name)
        {
            case "PointUp":
                goRigidbody.AddForce(Vector3.down * Random.Range(_minSpeed, _maxSpeed));
                break;
            case "PointDown":
                goRigidbody.AddForce(Vector3.up * Random.Range(_minSpeed, _maxSpeed));
                break;
            case "PointLeft":
                goRigidbody.AddForce(Vector3.right * Random.Range(_minSpeed, _maxSpeed));
                break;
            case "PointRight":
                goRigidbody.AddForce(Vector3.left * Random.Range(_minSpeed, _maxSpeed));
                break;

        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Spawner(
            _cubes[Random.Range(0, _cubes.Length)],
            _spawnPoints[Random.Range(1, _spawnPoints.Length)]));
    }
    
}
