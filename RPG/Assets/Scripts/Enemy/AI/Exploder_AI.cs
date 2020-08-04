using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder_AI : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    public float EngageRange;
    public float Speed;
    public float Damage;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Encounter()
    {
        if(Vector3.Distance(transform.position, Player.transform.position) < EngageRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>().Damage(Damage);
            Destroy(gameObject);

        }
       
    }

    // Update is called once per frame
    void Update()
    {
        Encounter();
    }
}
