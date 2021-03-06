﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood_Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 pos;
    SpriteRenderer SR;
    public float Range;
    public float DamageScale;
    public float SelfDamageScale;
    float Damage;
    float SelfDamage;
    float PlayerLevel;
    float counter;
    float StartScale;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0f);
        transform.position = pos;
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        Damage = DamageScale * PlayerLevel;
        SelfDamage = SelfDamageScale * PlayerLevel;
       
        StartScale = transform.localScale.x;
        SR.color = Color.clear;
    }


    void Spell()
    {
        counter += Time.deltaTime*2;
        SR.color = Color.Lerp(Color.clear, Color.red, counter);
        transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(StartScale, StartScale, 1), counter);
        if(counter >= 1)
        {
            GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>().Damage(SelfDamage);
            GameObject[] LocalEnemies = GameObject.FindGameObjectsWithTag("Damagable");
            for (int i = 0; i < LocalEnemies.Length; i++)
            {
                if (Vector3.Distance(transform.position, LocalEnemies[i].transform.position) < Range)
                {
                    if(LocalEnemies[i].GetComponent<Enemy_Health>() == null)
                    {
                        Destroy(LocalEnemies[i]);
                    }
                    else
                    {
                        LocalEnemies[i].GetComponent<Enemy_Health>().Damage(Damage);
                    }
                   
                }
            }
            Destroy(gameObject);
        }
    }


    void FuckUnity()
    {
        transform.Rotate(0f, 0f, 360 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Spell();
        FuckUnity();
    }
}
