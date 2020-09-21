using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frost_Rain : MonoBehaviour
{
    // Start is called before the first frame update
    float counter = 0;
    public float Range;
    public float Duration;
    public float DamageScale;
    public float Speed;
    GameObject Player;
    Resource_Manager RM;
    float Damage;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        RM = GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>();
        Damage = DamageScale * GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        
    }

    void Effect()
    {
       
        if(Vector3.Distance(Player.transform.position,transform.position) <= Range)
        {
            RM.Damage(Damage);
        }
     
    }
    void Motion()
    {
        transform.position = transform.position + new Vector3(-0.3f, -1.2f, 0f) * Time.deltaTime * Speed; ;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        Motion();
        if (counter >= Duration)
        {
            Effect();
            Destroy(gameObject);
        }
    }
}
