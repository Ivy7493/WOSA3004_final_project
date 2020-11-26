﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    public float ExpRewardScale;
    float ExpReward;
    [SerializeField]
    float BaseExp = 10f;
    Experience_Manager EM;
    void Start()
    {
        try
        {
            EM = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>();
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        catch
        {

        }
        
        
    }

    public void AwardExp()
    {
        ExpReward = BaseExp + BaseExp * (ExpRewardScale / 100f) * EM.ReturnLevel();
        if (Player != null)
        {
           
                EM.AddExp(ExpReward);
          
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
