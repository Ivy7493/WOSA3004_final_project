﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip StartingArea;
    public AudioClip FireArea;
    public AudioClip FireAreaAmbient;

    public AudioClip BossFight;
    public AudioClip IceBoss;
    public AudioClip IceArea;
    public AudioClip IceAreaAmbient;
    public AudioClip IceAreaAmbient2;

    AudioSource AS;
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void PlayStartingArea()
    {
        if(AS.clip != StartingArea)
        {
            AS.clip = StartingArea;
            AS.Play();
        }
       
    }

    public void PlayIceArea()
    {
        if(AS.clip != IceArea)
        {
            AS.clip = IceArea;
            AS.Play();
        }
    }

    public void PlayIceAreaAmbient()
    {
        if (AS.clip != IceAreaAmbient)
        {
            AS.clip = IceAreaAmbient;
            AS.Play();
        }
    }

    public void PlayIceAreaAmbient2()
    {
        if (AS.clip != IceAreaAmbient2)
        {
            AS.clip = IceAreaAmbient2;
            AS.Play();
        }
    }

    public void PlayIceBoss()
    {
        if(AS.clip != IceBoss)
        {
            AS.clip = IceBoss;
            AS.Play();
        }
    }

    public void PlayFireArea()
    {
        if(AS.clip != FireArea)
        {
            AS.clip = FireArea;
            AS.Play();
        }
       
    }

    public void PlayBossFight()
    {
        if(AS.clip != BossFight)
        {
            AS.clip = BossFight;
            AS.Play();
        }
       
    }

    public void DetermineMusic()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
