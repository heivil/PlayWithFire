using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float _speed = 5, _maxSpeed = 10, _speedIncrease = 0.1f;
    private Rigidbody2D _rb;
    private Vector2 _startVelocity;
    public GameObject _fireSplash;
    public Paddle _paddle;
    private Vector3 _splashOffset = new Vector3(0, 0.2f, 0);
    public GameObject _gameOverFire;
    private Quaternion _ogRotation;
    public AudioPlayer _audioPlayer;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startVelocity = new Vector2(0, _speed);
        _ogRotation = transform.rotation;
    }
    private void OnEnable()
    {
        transform.rotation = _ogRotation;
        _rb.velocity = transform.TransformDirection(_startVelocity);
    }

    /// <summary>
    /// Makes angle out of current rigid body velocity, and rotates transform to face velocitys direction
    /// </summary>
    private void FixedUpdate()
    {
        float angle = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg -90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    /// <summary>
    /// Takes the current local velocity, adds a small speed increase to that and applies the new speed to rigidbody.
    /// </summary>
    /// <param name="collision">Paddle</param>
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
            _audioPlayer.PlayBurn();
            transform.position = Vector2.zero;
            _rb.velocity = transform.TransformDirection(_startVelocity);
            gameObject.SetActive(false);
        }else if (collision.gameObject.layer == 6)
        {
            _fireSplash.transform.position = transform.position + transform.up / 2;
            _fireSplash.transform.rotation = collision.transform.rotation;
            _fireSplash.gameObject.SetActive(true);
        }
    }
}
