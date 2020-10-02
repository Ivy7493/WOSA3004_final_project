using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_spawn : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource AS;
    bool Set = false;
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void SetSound(AudioClip _clip)
    {
        AS = GetComponent<AudioSource>();
        Set = true;
        AS.clip = _clip;
        AS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Set == true && AS.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
