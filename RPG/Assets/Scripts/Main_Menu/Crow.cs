using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource AS;
    float counter;
    public float CrowFrequency;
    void Start()
    {
        AS = GetComponent<AudioSource>();
        counter = CrowFrequency;
    }

    void Effect()
    {
        if(AS.isPlaying == false)
        {
            counter += Time.deltaTime;
            if (counter >= CrowFrequency)
            {
                AS.Play();
                counter = 0f;
            }
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        Effect();
    }
}
