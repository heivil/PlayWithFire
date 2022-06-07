using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverFire : MonoBehaviour
{
    public GameObject _menu, _rotateButtons;
    public void GameOver()
    {
        _menu.SetActive(true);
        _rotateButtons.SetActive(false);
        gameObject.SetActive(false);
    }
}
