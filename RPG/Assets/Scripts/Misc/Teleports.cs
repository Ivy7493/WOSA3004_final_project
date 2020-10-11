using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleports : MonoBehaviour
{
    public Transform destination;
    public GameObject player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Works");
        player.transform.position = destination.transform.position;
    }


}
