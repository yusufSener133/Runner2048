using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    #endregion
    [SerializeField] MaxSpawnEnum _maxSpawn;
    public int MaxSpawnEnum { get { return (int)_maxSpawn; } }
    [SerializeField] int _missionValue;
    public int Mission { get { return _missionValue; } }

    [SerializeField] CollectController _collectController;
    public CollectController CollectController { get { return _collectController; } }

    [SerializeField] EndPoint _endPoint;
    public EndPoint EndPoint { get { return _endPoint; } }
    bool _mission;
    public bool MissionCheck 
    { 
        get
        {
            if (_missionValue <= _endPoint.MaxValue)
                _mission = true;
            else
                _mission = false;
            return _mission; 
        } 
    }
}
