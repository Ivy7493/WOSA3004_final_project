using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy;
    public float RespawnTime;
    public float DespawnDistance;
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
        if(CurrentSpawn != null)
        {
            if (Vector3.Distance(transform.position, CurrentSpawn.transform.position) < 1 && Vector3.Distance(Player.transform.position, transform.position) > DespawnDistance)
            {
                CurrentSpawn.SetActive(false);
            }
            else
            {
                CurrentSpawn.SetActive(true);
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        Spawn();
        Despawn();
    }
}
