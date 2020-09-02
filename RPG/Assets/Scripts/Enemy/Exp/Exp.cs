using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    public float ExpRewardScale;
    float ExpReward;
    Experience_Manager EM;
    void Start()
    {
        EM = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>();
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }

    public void AwardExp()
    {
        ExpReward = EM.ReturnLevel() * ExpRewardScale;
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
