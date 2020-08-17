using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame_Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    Resource_Manager RM;
    public float Damage;
    float counter;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        RM = GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>();
    }

    void Encounter()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            RM.Damage(Damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter >= 0.3f)
        {
            Destroy(gameObject);
        }
    }
}
