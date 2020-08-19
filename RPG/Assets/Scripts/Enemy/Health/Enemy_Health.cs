using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float HealthScale;
    float Health;
    float MaxHealth;
    float PlayerLevel;
    public GameObject HUD;
    void Start()
    {
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        Health = PlayerLevel * HealthScale;
        MaxHealth = Health;
        if(HUD != null)
        {
            HUD.GetComponent<UI_Enemy_HUD>().UpdateHealthBar(1f);
        }
    }

    public float ReturnMaxHealth()
    {
        return MaxHealth;
    }

    public float ReturnCurrentHealth()
    {
        return Health;
    }


    public void Damage(float _damage)
    {
        Health -= _damage;
        if(HUD != null)
        {
            float temp = Health / MaxHealth;
            HUD.GetComponent<UI_Enemy_HUD>().UpdateHealthBar(temp);
        }
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
