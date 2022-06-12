using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource _source;
    public AudioClip _paddleBoing, _burn;

    void Awake()
    {
        _source = GetComponent<AudioSource>(); 
    }

    public void PlayBoing()
    {
        _source.PlayOneShot(_paddleBoing);
    }
  
    public void PlayBurn()
    {
        _source.PlayOneShot(_burn);

    }
}
