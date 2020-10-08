using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SpawnPrefab;
    public AudioClip PlayerDamage;
    public AudioClip PlayerDeath;
    public AudioClip PlayerDeath2;


    void Start()
    {
        Debug.Log("Yo");
    }

    public void PlaySound(AudioClip _clip)
    {
        GameObject temp = Instantiate(SpawnPrefab, transform.position, Quaternion.identity);
        temp.GetComponent<Sound_spawn>().SetSound(_clip);
    }

    public void PlaySound(AudioClip _clip, float volume)
    {
        GameObject temp = Instantiate(SpawnPrefab, transform.position, Quaternion.identity);
        temp.GetComponent<Sound_spawn>().SetSound(_clip);
        temp.GetComponent<AudioSource>().volume = volume;
    }

    public void PlayDeathSound()
    {
        PlaySound(PlayerDeath);
        PlaySound(PlayerDeath2);
    }

    public void PlayPlayerDamage()
    {
        //float RandomNum = Random.Range(1f, 2f);
        //if (RandomNum == 1f) 
        //{
            PlaySound(PlayerDamage, 0.4f); 
        //}
        //else
        //{

        //}
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
