using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RotateArrows : MonoBehaviour
{
    public Paddle _paddle;
    private bool _isRightPressed, _isLeftPressed;


    private void OnDisable()
    {
        _isRightPressed = false;
        _isLeftPressed = false;
    }

    void Update()
    {
        if (_isLeftPressed)
        {
            _paddle.RotateLeft();
        }else if (_isRightPressed)
        {
            _paddle.RotateRight();
        }
    }

    public void OnPointerDownLeft()
    {
        _isLeftPressed = true;
    }

    public void OnPointerUpLeft()
    {
        _isLeftPressed = false;
    }

    public void OnPointerDownRight()
    {
        _isRightPressed = true;
    }

    public void OnPointerUpRight()
    {
        _isRightPressed = false;
    }
}
