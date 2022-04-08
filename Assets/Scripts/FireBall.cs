using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float _speed = 5, _maxSpeed = 10, _speedIncrease = 0.1f;
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

    private void FixedUpdate()
    {
        float angle = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg -90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if(_rb.velocity.magnitude < 10)
            {
                Vector2 localVelocity = transform.InverseTransformDirection(_rb.velocity);
                Vector2 newVelocity = new Vector2(0, localVelocity.y + _speedIncrease);
                _rb.velocity = transform.TransformDirection(newVelocity);
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            transform.position = Vector2.zero;
            _rb.velocity = transform.TransformDirection(_startVelocity);
        }
    }
}
