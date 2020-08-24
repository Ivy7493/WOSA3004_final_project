using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicTrap : MonoBehaviour
{
    // Start is called before the first frame update
    public float Range;
    public float DamageScale;
    public float Duration;
    public float TickRate;
    float Damage;
    Vector3 pos;
    void Start()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0f);
        transform.position = pos;
        transform.localScale = new Vector3(Range*2, Range*2, 1f);
        Damage = DamageScale * GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        InvokeRepeating("Spell", 0, TickRate);
    }

    void Spell()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Damagable");
        for(int i = 0; i < Enemies.Length; i++)
        {
            try
            {
                if(Vector3.Distance(transform.position,Enemies[i].transform.position) < Range)
                {
                    Enemies[i].GetComponent<Enemy_Health>().Damage(Damage);
                }
            }
            catch
            {
                Debug.Log("Couldnt find Enemy Health component");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Duration -= Time.deltaTime;
        if(Duration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
