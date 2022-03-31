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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Vector2 currentVelocity = _rb.velocity;
            Vector2 collisionNormal = collision.contacts[0].normal;
            Vector2 newVelocity = Vector2.Reflect(currentVelocity, collisionNormal);
            print(_rb.velocity);
            _rb.velocity = _rb.velocity * -1;
            collision.gameObject.SetActive(false);
            print(_rb.velocity);
        }
    }
}
