using System.Collections;
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
    public AudioClip IceArea2;

    bool IceAreaMusic = false;

    AudioSource AS;
    Sound_Manager SM;
    void Start()
    {
        AS = GetComponent<AudioSource>();
        SM = GameObject.FindGameObjectWithTag("Sound_Manager").GetComponent<Sound_Manager>();
    }

    public void PlayStartingArea()
    {
        if(AS.clip != StartingArea)
        {
            AS.clip = StartingArea;
            AS.Play();
        }
       
    }

   

    IEnumerator PlaySoundOnDelay(AudioClip _clip, float time)
    {
        yield return new WaitForSeconds(time);
        SM.PlaySound(_clip);

    }

    public void PlayIceArea()
    {
        if(AS.clip != IceArea || AS.clip != IceArea2)
        {
            switch(IceAreaMusic)
            {
                case true:
                    AS.clip = IceArea;
                    AS.Play();
                    IceAreaMusic = false;
                    break;
                case false:
                    AS.clip = IceArea2;
                    AS.Play();
                    IceAreaMusic = true;
                    break;
            }
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
