using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float Health;
    void Start()
    {
        
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
