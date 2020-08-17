using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    public float ExpDistance;
    public float ExpReward;
    Experience_Manager EM;
    void Start()
    {
        EM = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnDestroy()
    {
        if(Player != null)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) < ExpDistance)
            {
                EM.AddExp(ExpReward);
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
