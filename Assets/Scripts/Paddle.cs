using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float _rotateSpeed = 5f;
    public float _radius = 5f;
    public GameObject _center;
    private float _angle;
    private int _shrinkCounter = 0, _hitCounter = 0;
    public int _shrinkInterval = 5;
    private SpriteRenderer _renderer;
    private Animator _animator;
    public Sprite[] _sprites = new Sprite[12];
    private  BoxCollider2D _collider; 

    private void Awake()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        _collider = gameObject.GetComponent<BoxCollider2D>();
        _animator = gameObject.GetComponent<Animator>();
    }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            _hitCounter++;
            _animator.SetTrigger("Hit");
            if (_hitCounter == _shrinkInterval && _shrinkCounter < 11)
            {
                _shrinkCounter++;
                _hitCounter = 0;
                _renderer.sprite = _sprites[_shrinkCounter];
                _collider.size = _renderer.sprite.bounds.size;
                
            }
        }
    }
}
