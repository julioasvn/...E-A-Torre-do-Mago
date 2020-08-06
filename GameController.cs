using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Camera      cam;
    public Transform    playerTransform;

    public AudioSource  sfxSource;
    public AudioSource  musicSource;
    //public AudioClip    sfxJump;
    public AudioClip    sfxAtack;
    public AudioClip[]  sfxStep;

    void Start()
    {
        cam = Camera.main;
    }

    
    void Update()
    {
        
    }

    public void playSFX(AudioClip sfxClip, float volume) 
    {
        sfxSource.PlayOneShot(sfxClip, volume);
    }

    
}
