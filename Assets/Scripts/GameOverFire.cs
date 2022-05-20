using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverFire : MonoBehaviour
{
    public GameObject _menu;
    public void GameOver()
    {
        _menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
