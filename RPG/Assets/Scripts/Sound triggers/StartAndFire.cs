using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartAndFire : MonoBehaviour
{
    GameObject Player;
    Music_Manager MM;
    public float TriggerDistance;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        MM = GameObject.FindGameObjectWithTag("Music_Manager").GetComponent<Music_Manager>();
       
    }

    void ChangeSound()
    {
        if (Player.transform.position.y > transform.position.y && Vector3.Distance(transform.position, Player.transform.position) < TriggerDistance)
        {
            MM.PlayStartingArea();
          

        }
        else if (Player.transform.position.y < transform.position.y && Vector3.Distance(transform.position, Player.transform.position) < TriggerDistance)
        {
            MM.PlayFireArea();
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSound();
    }
}
