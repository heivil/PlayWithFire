using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paddle : MonoBehaviour
{
    public float _rotateSpeed = 5f;
    public float _radius = 5f;
    public GameObject _center, _poofs;
    private float _angle;
    private int _shrinkCounter = 0, _hitCounter = 0;
    public int _shrinkInterval = 5;
    private SpriteRenderer _renderer;
    private Animator _animator;
    public Sprite[] _sprites = new Sprite[12];
    private  BoxCollider2D _collider;
    private int _score = 0;
    public TextMeshProUGUI _scoreText;
    public AudioPlayer _audioPlayer;

    public int Score
    {

        set { _score = value; }
        get { return _score; }
    }
    public float GetLength()
    {
        return _renderer.sprite.bounds.size.x;
    }

    private void Awake()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        _collider = gameObject.GetComponent<BoxCollider2D>();
        _animator = gameObject.GetComponent<Animator>();
    }
    public void ResetPos()
    {
        _angle = 0;
        Vector2 offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * _radius;
        transform.position = (Vector2)_center.transform.position - offset;
        transform.up = _center.transform.position - transform.position;
        _shrinkCounter = 0;
        _hitCounter = 0;
        _renderer.sprite = _sprites[0];
        _collider.size = _renderer.sprite.bounds.size;
    }
    private void Update()
    {
        if (Input.GetKey("left"))
        {
            RotateLeft();
        }
        else if (Input.GetKey("right"))
        {
            RotateRight();
        }
    }

    public void RotateRight()
    {
        RotateAndLook(-_rotateSpeed);
    }

    public void RotateLeft()
    {
        RotateAndLook(_rotateSpeed);
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
            _score++;
            _scoreText.text = _score.ToString();
            _poofs.SetActive(true);
            _audioPlayer.PlayBoing();
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
