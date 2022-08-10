using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectedCube : MonoBehaviour
{
    Transform _collector;

    void Awake()
    {
        _collector = transform.Find("Collector");
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.deltaPosition.x > 40f)
            {
                Movement(Vector3.right);
            }
            if (touch.deltaPosition.x < -40f)
            {
                Movement(Vector3.left);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject cube = collision.gameObject;
        if (cube.tag == "Cube" && cube.GetComponent<CubeManager>().Value != GetComponent<CubeManager>().Value)
        {
            cube.transform.SetParent(_collector);
            cube.tag = "CollectedCube";
            cube.AddComponent<CollectedCube>();
        }
    }

    void Movement(Vector3 _direction)
    {
        float point = 1.2f;
        float endPos = transform.position.x;

        if (_direction == Vector3.right)
            point *= 1;
        else if (_direction == Vector3.left)
            point *= -1;

        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(_direction), out hit, 10f);
        Debug.DrawRay(transform.position, transform.TransformDirection(_direction) * hit.distance, Color.red);
        if (hit.transform.gameObject.tag == "Wall")
        {
            endPos = hit.transform.position.x - point;
        }
        else if (hit.transform.gameObject.tag == "CollectedCube")
        {
            if (hit.transform.GetComponent<CubeManager>().Value == transform.GetComponent<CubeManager>().Value)
            {
                endPos = hit.transform.position.x;
            }
            else
            {
                endPos = hit.transform.position.x - point;
            }
        }
        transform.DOMoveX(endPos, 10f * Time.deltaTime);
    }


}

