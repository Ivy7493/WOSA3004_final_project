using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Fire_Ball : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    AIDestinationSetter Motor;
    public float TrackTimer;
    public float DamageScale;
    float PlayerLevel;
    float Damage;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Motor = GetComponent<AIDestinationSetter>();
        Motor.target = Player.transform;
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        Damage = PlayerLevel * DamageScale;
    }

    void Encounter()
    {
        TrackTimer -= Time.deltaTime;
        if(TrackTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>().Damage(Damage);
            Destroy(gameObject);
        }
        Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        Encounter();
    }
}
