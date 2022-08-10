using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCube : MonoBehaviour
{
    MainSpawnManager MainSpawnManager;
    void OnEnable()
    {
        MainSpawnManager = FindObjectOfType<MainSpawnManager>();
    }
    void OnDestroy()
    {
        Destroy(Instantiate(MainSpawnManager.Effect[Random.Range(0, MainSpawnManager.Effect.Length)], transform.position, Quaternion.identity), 3f);
    }
}
