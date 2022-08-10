using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeManager : MonoBehaviour
{
    [SerializeField] GameObject _nextCube;
    [SerializeField] int _value;
    public int Value { get { return _value; } }

    int _id;
    public int ID { get { return _id; } }

    Rigidbody _rb;

    void Awake()
    {
        _id = GetInstanceID();
        _rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        if (collision.gameObject.tag == "Cube" || collision.gameObject.tag == "CollectedCube")
        {
            if (collision.gameObject.TryGetComponent(out CubeManager anotherCube))
            {
                if (anotherCube._value == _value)
                {
                    if (_id < anotherCube.ID) return;

                    Camera.main.DOShakePosition(0.2f,0.1f,fadeOut:true);
                    Destroy(this.gameObject);
                    Destroy(collision.gameObject);
                    
                    if (_nextCube != null)
                    {
                        Instantiate(_nextCube, collision.transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
