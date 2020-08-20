using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    UI_Manager UIM;
    GameObject Player;
    void Start()
    {
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    public void Death()
    {
        GameObject[] SpawnPoints = GameObject.FindGameObjectsWithTag("RespawnPoint");
        float ShortDistance = 1000f;
        int SavedIndex = 0;
        for(int i = 0; i < SpawnPoints.Length; i++)
        {
            if(Player != null)
            {
                if(Vector3.Distance(Player.transform.position,SpawnPoints[i].transform.position) < ShortDistance)
                {
                    ShortDistance = Vector3.Distance(Player.transform.position, SpawnPoints[i].transform.position);
                    SavedIndex = i;
                }
            }
        }
        UIM.CallDeathEffect();
        Player.transform.position = SpawnPoints[SavedIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
