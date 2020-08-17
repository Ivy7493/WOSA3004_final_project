using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame_archer_AI : MonoBehaviour
{
    // Start is called before the first frame update
    public float EngageRange;
    public float AbilityFrequency;
    public GameObject FireBall;
    float offset = 2.5f;
    GameObject Player;
    float counter = 0f;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        counter = AbilityFrequency;
    }


    void encounter()
    {
       
        if(Vector3.Distance(transform.position,Player.transform.position) < EngageRange)
        {
           
            counter += Time.deltaTime;
            if(counter >= AbilityFrequency)
            {
                Vector3 Direction = (Player.transform.position - transform.position).normalized;
                Instantiate(FireBall, transform.position + (Direction * offset), Quaternion.identity);
                counter = 0;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        encounter();
    }
}
