using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaShield : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    public float Duration;
    SpriteRenderer SR;
    float counter;
    bool Switch = false;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        SR = GetComponent<SpriteRenderer>();
    }

    void Spell()
    {
        Debug.Log("Working");
        transform.position = Player.transform.position;
        Duration -= Time.deltaTime;
        if(Duration <= 0)
        {
            Destroy(gameObject);
        }
        
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damagable")
        {
            try
            {
                collision.gameObject.GetComponent<Enemy_Health>().Damage((collision.gameObject.GetComponent<Enemy_Health>().ReturnCurrentHealth() /100 )*Time.deltaTime);
            }
            catch
            {

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        
       
    }

    // Update is called once per frame
    void Update()
    {
        Spell();
    }
}
