using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuake : MonoBehaviour
{
    // Start is called before the first frame update
    public float Range;
    public float DamageScale;
    float PlayerLevel;
    float Damage;
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        Damage = DamageScale * PlayerLevel;
        SpellMain();
    }


    void SpellMain()
    {
        GameObject[] LocalEnemies = GameObject.FindGameObjectsWithTag("Damagable");
        for (int i = 0; i < LocalEnemies.Length; i++)
        {
            if(Vector3.Distance(Player.transform.position,LocalEnemies[i].transform.position) < Range)
            {
                LocalEnemies[i].GetComponent<Enemy_Health>().Damage(Damage);
            }
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
