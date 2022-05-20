using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofAwayer : MonoBehaviour
{
    // Makes poof go away
    public void PoofAway()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
