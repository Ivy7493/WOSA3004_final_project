using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    UI_Manager UIM;
    GameObject Player;
    Effect_Manager EFM;
    float KeyCount = 0;
    float FirstBoss = 0;
    float FrostBoss = 0f;
    public GameObject DefaultSpawn;
    public GameObject CenteralSpawn;
    private void Awake()
    {
        LoadGameData();
    }


    void Start()
    {
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        Player = GameObject.FindGameObjectWithTag("Player");
        EFM = GameObject.FindGameObjectWithTag("Effect_Manager").GetComponent<Effect_Manager>();
    }

    //Loads Saved Game Data assosiated with the Game Manager
    void LoadGameData()
    {
        KeyCount = PlayerPrefs.GetFloat("KeyCount", 0);
        FirstBoss = PlayerPrefs.GetFloat("FirstBoss", 0);
        FrostBoss = PlayerPrefs.GetFloat("FrostBoss", 0);
    }


    //Function used to check if bosses are alive or dead when game starts
    public float ReturnBossStatus(string _boss)
    {
        switch (_boss)
        {
            case "FIRE":
                return FirstBoss;
                break;
            case "FROST":
                return FrostBoss;
                break;
        }
        return 2;
    }


    //function called when bosses are defeated for the first time, will make sure they dont spawn next time the game is laoded
    public void BossDefeated(string _boss)
    {
        switch (_boss)
        {
            case "FIRE":
                FirstBoss = 1;
                PlayerPrefs.SetFloat("FirstBoss", 1);
                KeyCount++;
                EFM.ScreenShake(2f);
                break;
            case "FROST":
                FrostBoss = 1;
                PlayerPrefs.SetFloat("FrostBoss", 1);
                KeyCount++;
                EFM.ScreenShake(2f);
                break;
        }

        UIM.SendNotification("Warden Defeated", 5f);
       
    }


   
    //Just saving data that needs to be saved here
    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("KeyCount", KeyCount);
    }


    bool CheckSpawn()
    {
        if(PlayerPrefs.GetFloat("CenterSpawn",0) == 1f){
            return true;
        }
        return false;
    }


    //When the player dies the game manager looks for the closest respawn point and teleports the player to that resapwn point
    // it also calls the UI Death effect
    public void Death()
    {
        if(CheckSpawn() == true)
        {
            UIM.CallDeathEffect();
            Player.transform.position = CenteralSpawn.transform.position;
        }else if(CheckSpawn() == false)
        {
            UIM.CallDeathEffect();
            Player.transform.position = DefaultSpawn.transform.position;
        }
      
        /*
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
        */
    }

    void SetSpawnCenter()
    {
        if(Vector3.Distance(Player.transform.position,CenteralSpawn.transform.position) < 3 && PlayerPrefs.GetFloat("CenterSpawn",0f) == 0f)
        {
            PlayerPrefs.SetFloat("CenterSpawn", 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetSpawnCenter();
    }
}
