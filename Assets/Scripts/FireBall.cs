using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float _speed = 5, _maxSpeed = 10;
    private Rigidbody2D _rb;
    private Vector2 _startVelocity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startVelocity = new Vector2(0, _speed);
    }
    private void Start()
    {
        _rb.velocity = transform.TransformDirection(_startVelocity);
    }

    private void Update()
    {
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg -90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
