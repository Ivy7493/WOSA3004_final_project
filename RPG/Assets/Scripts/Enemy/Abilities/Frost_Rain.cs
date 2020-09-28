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
    Vector3 Direction;
    float Damage;
    bool Set = false;
    float SinCounter = 0f;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        RM = GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>();
        Damage = DamageScale * GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
       // Direction = (Player.transform.position - transform.position).normalized;
    }

    public void SetDirection(Vector3 _direction)
    {
        Direction = _direction;
        Set = true;
    }

    void Effect()
    {
        //new Vector3(-0.3f, -1.2f, 0f)
        if (Vector3.Distance(Player.transform.position,transform.position) <= Range)
        {
            RM.Damage(Damage);
        }
     
    }
    void Motion()
    {
        counter += Time.deltaTime;
        transform.position = transform.position + Direction* Time.deltaTime * Speed * 1/2;
        transform.position = new Vector3(transform.position.x + 1/2*Mathf.Cos(5*counter), transform.position.y + 1/2*Mathf.Sin(5*counter), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Set == true)
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
}
