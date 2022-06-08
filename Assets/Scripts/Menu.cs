using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject _fireBall, _playText, _shouldNotPlayText;
    public Paddle _paddle;
    public Sprite _startBG, _gameOverBG, _unmutedUnpressed, _mutedUnpressed;
    public Button _muteButton;
    private Image _BG;
    public GameObject _rotateButtons;
    public SpriteState _unmutedState, _mutedState;

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
        _rotateButtons.SetActive(true);
    }

    public void Mute()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            _muteButton.spriteState = _mutedState;
            _muteButton.image.sprite = _mutedUnpressed;
        }
        else
        {
            AudioListener.volume = 1;
            _muteButton.spriteState = _unmutedState;
            _muteButton.image.sprite = _unmutedUnpressed;
        }
        
    }
}