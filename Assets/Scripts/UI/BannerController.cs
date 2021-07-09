using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerController : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioPlayer;

    public bool animating;


    void Start()
    {
        animator = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    public void playVoice(AudioClip voice)
    {
        audioPlayer.PlayOneShot(voice, 1f);
    }

    public void animationEnded()
    {
        animating = false;
    }

    public void showFight()
    {
        animating = true;
        animator.SetTrigger("ShowFight");
    }

    public void showGameEnd()
    {
        animating = true;
        animator.SetTrigger("GameOver");
        
    }
    public bool inAnimating
    {
        get
        {
            return animating;
        }
    }
}
