using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy;
    public float RespawnTime;
    public float DespawnDistance;
    public float ResetDistance;
    GameObject CurrentSpawn;
    GameObject Player;
    float counter;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        counter = RespawnTime;
    }


    void Spawn()
    {
        if(CurrentSpawn == null && counter >= RespawnTime && Vector3.Distance(transform.position, Player.transform.position) < DespawnDistance)
        {
            CurrentSpawn = Instantiate(Enemy, transform.position, Quaternion.identity);
            counter = 0;
        }
    }

    void Despawn()
    {
        if(Vector3.Distance(transform.position,Player.transform.position) > DespawnDistance)
        {
            if (CurrentSpawn != null)
            {
                CurrentSpawn.SetActive(false);
            }
            
        }
        else
        {
            if(CurrentSpawn != null)
            {
                if (CurrentSpawn.activeInHierarchy == false)
                {
                    CurrentSpawn.SetActive(true);
                }
            }
           
        }
    }

    void ResetEnemy()
    {
        if(CurrentSpawn != null)
        {
            if (Vector3.Distance(transform.position, CurrentSpawn.transform.position) > ResetDistance)
            {
                CurrentSpawn.transform.position = transform.position;
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        Spawn();
        Despawn();
        ResetEnemy();
    }
}
