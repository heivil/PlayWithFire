using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject _fireBall, _playText, _shouldNotPlayText;
    public Paddle _paddle;
    public Sprite _startBG, _gameOverBG;
    private Image _BG;


    private void Awake()
    {
        _BG = gameObject.GetComponent<Image>();
        _BG.sprite = _startBG;
        _playText.SetActive(true);
    }

    public void StartGame()
    {
        _fireBall.SetActive(true);
        _paddle.ResetPos();
        _BG.sprite = _gameOverBG;
        _playText.SetActive(false);
        _shouldNotPlayText.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Mute()
    {
        ///mutesoinfsadfs
    }
}