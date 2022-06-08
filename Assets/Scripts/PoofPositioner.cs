using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofPositioner : MonoBehaviour
{
    public GameObject _poofRight, _poofLeft;
    public Paddle _paddle;

    /// <summary>
    /// Positions poofs on left and right side of the transform (local space), according to paddles length 
    /// </summary>
    private void OnEnable()
    {
        _poofRight.transform.position = transform.position + transform.right * _paddle.GetLength() / 2;
        _poofLeft.transform.position = transform.position - transform.right * _paddle.GetLength() / 2;
    }
}
