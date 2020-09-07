using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip StartingArea;
    public AudioClip FireArea;
    public AudioClip BossFight;
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
