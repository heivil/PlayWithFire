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
        _poofRight.transform.position = new Vector2(transform.right.x * _paddle.GetLength() / 2, transform.position.y);
        _poofLeft.transform.position = new Vector2(-transform.right.x * _paddle.GetLength() / 2, transform.position.y);
    }
}
