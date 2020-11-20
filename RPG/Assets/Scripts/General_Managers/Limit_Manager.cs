using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] Missiles;
    void Start()
    {
        
    }


    public int ReturnMissileCount()
    {
        return Missiles.Length;
    }


    void MissileLimit()
    {
        Missiles = GameObject.FindGameObjectsWithTag("Missile");
    }

    // Update is called once per frame
    void Update()
    {
        MissileLimit();
    }
}
