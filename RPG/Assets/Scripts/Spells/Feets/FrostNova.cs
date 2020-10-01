using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostNova : MonoBehaviour
{
    // Start is called before the first frame update
    public float Range;
    public float DamageScale;
    public float TickRate;
    public float Duration;
    public float SlowDuration;
    public float Slow;
    float Damage;
    float counter;
    bool Switch = false;
    SpriteRenderer SR;
    GameObject Player;
    void Start()
    {
        Damage = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel() * DamageScale;
        SR = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Spell", 0f, TickRate);
        transform.localScale = new Vector3(0.3f + Range * 2,0.3f + Range * 2, 1f);
    }

    void Spell()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Damagable");
        for (int i = 0; i < Enemies.Length; i++)
        {
            try
            {
                if (Vector3.Distance(transform.position, Enemies[i].transform.position) < Range)
                {
                    Enemies[i].GetComponent<Enemy_Health>().Damage(Damage);
                }
            }
            catch
            {
                Debug.Log("Couldnt find Enemy Health component");
            }
            try
            {
                if (Vector3.Distance(transform.position, Enemies[i].transform.position) < Range)
                {
                    Enemies[i].GetComponent<Enemy_Status>().SetEnemySlow(Slow,SlowDuration);
                }
            }
            catch
            {

            }
        }
    }

    void Effect()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 0.5f,0f);
       
    }

    // Update is called once per frame
    void Update()
    {
        Duration -= Time.deltaTime;
        Effect();
        if(Duration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
