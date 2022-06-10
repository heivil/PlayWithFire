using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverFire : MonoBehaviour
{
    public GameObject _menu, _rotateButtons;
    public Paddle _paddle;
    public TextMeshProUGUI _score;
    public void GameOver()
    {
        _menu.SetActive(true);
        _score.text = "0";
        _paddle.Score = 0;
        _rotateButtons.SetActive(false);
        gameObject.SetActive(false);
    }
}
