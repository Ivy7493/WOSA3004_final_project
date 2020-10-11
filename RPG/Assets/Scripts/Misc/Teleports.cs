using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleports : MonoBehaviour
{
    public Transform destination;
    GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = new Vector3(destination.transform.position.x,destination.transform.position.y,0f);
    }


}
