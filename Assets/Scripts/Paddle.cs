using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float _rotateSpeed = 5f;
    public float _radius = 5f;
    public GameObject _center;
    private float _angle;
    private void Start()
    {
        Vector2 offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * _radius;
        transform.position = (Vector2)_center.transform.position - offset;
        transform.up = _center.transform.position - transform.position;
    }
    private void Update()
    {
        if (Input.GetKey("left"))
        {
            RotateAndLook(_rotateSpeed);
        }
        else if (Input.GetKey("right"))
        {
            RotateAndLook(-_rotateSpeed);
        }
    }

    private void RotateAndLook(float rotateSpeed)
    {
        _angle += rotateSpeed * Time.deltaTime;
        Vector2 offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * _radius;
        transform.position = (Vector2)_center.transform.position - offset;
        transform.up = _center.transform.position - transform.position;
    }
}
