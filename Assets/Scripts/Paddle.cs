using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float RotateSpeed = 5f;
    public float Radius = 5f;

    private Vector2 _centre;
    private float _angle;

    private void Start()
    {
        _centre = Vector2.zero;
    }

    private void Update()
    {
        _angle += RotateSpeed * Time.deltaTime;

        Vector2 offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
        print(offset);
    }
}
