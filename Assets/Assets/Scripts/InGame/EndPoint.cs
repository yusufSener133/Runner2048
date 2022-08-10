using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] GameObject[] _effects;
    int _score = 0;
    public int Score { get { return _score; } }

    int _maxValue = 0;
    public int MaxValue { get { return _maxValue; } }
    
    bool _theEnd;
    public bool TheEnd { get { return _theEnd; } set { _theEnd = value; } }


    void Awake()
    {
        _score = 0;
        _maxValue = 0;
        _theEnd = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CollectedCube")
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin")+1);
            GameObject cube = collision.gameObject;

            _score += cube.GetComponent<CubeManager>().Value;
            if (_maxValue < cube.GetComponent<CubeManager>().Value)
                _maxValue = cube.GetComponent<CubeManager>().Value;
            Destroy(Instantiate(_effects[Random.Range(0, _effects.Length)],collision.transform.position,Quaternion.identity),3);
            Destroy(collision.gameObject);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "End")
        {
            _theEnd = true;
        }
    }
}
