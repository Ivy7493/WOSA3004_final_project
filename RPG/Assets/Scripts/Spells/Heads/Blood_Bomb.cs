﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood_Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 pos;
    SpriteRenderer SR;
    public float Range;
    public float Damage;
    public float SelfDamage;
    float counter;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0f);
        transform.position = pos;
        GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>().Damage(SelfDamage);
        
    }


    void Spell()
    {
        counter += Time.deltaTime*2;
        SR.color = Color.Lerp(Color.clear, Color.red, counter);
        transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(Range, Range, 1), counter);
        if(counter >= 1)
        {
            GameObject[] LocalEnemies = GameObject.FindGameObjectsWithTag("Damagable");
            for (int i = 0; i < LocalEnemies.Length; i++)
            {
                if (Vector3.Distance(transform.position, LocalEnemies[i].transform.position) < Range)
                {
                    LocalEnemies[i].GetComponent<Enemy_Health>().Damage(Damage);
                }
            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Spell();
    }
}