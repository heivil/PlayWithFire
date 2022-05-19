using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float _speed = 5, _maxSpeed = 10, _speedIncrease = 0.1f;
    private Rigidbody2D _rb;
    private Vector2 _startVelocity;
    public GameObject _fireSplash;
    private Vector3 _splashOffset = new Vector3(0, 0.2f, 0);
    public GameObject _gameOverFire;

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
            _gameOverFire.SetActive(true);
            transform.position = Vector2.zero;
            _rb.velocity = transform.TransformDirection(_startVelocity);
        }else if (collision.gameObject.layer == 6)
        {
            _fireSplash.transform.position = transform.position + transform.up / 2;
            _fireSplash.transform.rotation = collision.transform.rotation;
            _fireSplash.gameObject.SetActive(true);
        }
    }
}
