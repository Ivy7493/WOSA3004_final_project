using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float HealthScale;
    float Health;
    float PlayerLevel;
   
    void Start()
    {
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        Health = PlayerLevel * HealthScale;
    }


    public void Damage(float _damage)
    {
        Health -= _damage;
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
