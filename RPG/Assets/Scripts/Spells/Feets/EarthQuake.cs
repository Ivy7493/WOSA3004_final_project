using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuake : MonoBehaviour
{
    // Start is called before the first frame update
    public float Range;
    public float DamageScale;
    public float MiniStun;
    public float TickRate;
    public float LifeScale;
    float PlayerLevel;
    float Damage;
    GameObject Player;
    SpriteRenderer SR;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        Damage = DamageScale * PlayerLevel;
        //SpellMain();
        StartCoroutine(DestoryAfter(2f));
        GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>().Damage(LifeScale * PlayerLevel);
        InvokeRepeating("SpellMain", 0f, TickRate);
    }

    IEnumerator DestoryAfter(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    void SpellMain()
    {
        GameObject[] LocalEnemies = GameObject.FindGameObjectsWithTag("Damagable");
        for (int i = 0; i < LocalEnemies.Length; i++)
        {
            if(Vector3.Distance(transform.position,LocalEnemies[i].transform.position) < Range)
            {
               
                try
                {
                    LocalEnemies[i].GetComponent<Enemy_Health>().Damage(Damage * TickRate);
                    LocalEnemies[i].GetComponent<Enemy_Status>().SetEnemyStun(MiniStun);
                }
                catch
                {
                    Debug.Log("Enemy is immune to cc");
                }
                
            }
        }
       // Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
