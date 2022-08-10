using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    [SerializeField] [Range(10, 1000)] float _speed = 100f;
    [SerializeField] bool _isRunning;
    public bool IsRunning { get { return _isRunning; } set { _isRunning = value; } }
    Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (_isRunning)
            _rb.velocity = Vector3.forward * _speed * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            GameObject cube = collision.gameObject;
            cube.transform.SetParent(this.transform);
            cube.tag = "CollectedCube";
            cube.AddComponent<CollectedCube>();
        }
    }

}
