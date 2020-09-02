using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Boss_AI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] FireLocations;
    public GameObject FireBombs;
    public GameObject FireBall;
    GameObject Player;
    Game_Manager GM;
    Enemy_Health EM;
    float CurrentStage = 0;
    float counter = 0f;
    public float StageTime;
    public float EngageRange;
    public float CameraZoom;
    public float SwipeRange;
    public float SwipeDamageScale;
    public float NumOfFireBall;
    float CameraStart;
    float Status;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
        ///returns the status of the boss to see whether we must keep the spawn or not
        Status = GM.ReturnBossStatus("FIRE");
        CheckBossStatus();
        //Just a function to change camera size when player gets close to boss
        CameraStart = Camera.main.orthographicSize;
        InvokeRepeating("CameraProspective", 0, 0.1f);
        EM = GetComponent<Enemy_Health>();
    }


    /// <summary>
    /// Checks to see if the boss has been killed already if so, it destorys the boss
    /// </summary>
    void CheckBossStatus()
    {
        if(Status == 1)
        {
            Destroy(gameObject);
        }
    }

    void CheckHealth()
    {
        if(EM.ReturnCurrentHealth() <= 0)
        {
            GM.BossDefeated("FIRE");
        }
    }


    //Stuff that must occur when boss dies
    private void OnDestroy()
    {
        if(Status == 1)
        {

        }else if(Status == 0)
        {
            CheckHealth();
        }

        Camera.main.orthographicSize = CameraStart;
    }

    //THe explosive ability of the boss
    void RainFire()
    {
        float Select = Random.Range(0, FireLocations.Length);
        for(int i = 0; i <= Select; i++)
        {
            Instantiate(FireBombs, FireLocations[i].transform.position, Quaternion.identity);
        }

    }


    //melee swipe of the boss, missing animation!
    void Swipe()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) < SwipeRange)
        {
            float Damage = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel() * SwipeDamageScale;
            GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>().Damage(Damage);
        }
    }

    //Spawns A lot of fire balls
    void FireBalls()
    {
        float Tempcounter = 0;
        while(Tempcounter != NumOfFireBall)
        {
            Tempcounter++;
            float RandomDiff = Random.Range(-3f, 3f);
            Vector3 SpawnPos = new Vector3(transform.position.x + RandomDiff, transform.position.y + RandomDiff, 0f);
            Instantiate(FireBall, SpawnPos, Quaternion.identity);
        }
    }


    //will zoom the camera out when the player gets close to the boss
    void CameraProspective()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) < EngageRange)
        {
            float CameraSize = Camera.main.orthographicSize;
            
            if(CameraSize < CameraZoom)
            {
                Debug.Log("HERE!");
                Camera.main.orthographicSize += 0.2f;
            }
            
        }
        else if(Vector3.Distance(Player.transform.position, transform.position) > EngageRange)
        {
            float CameraSize = Camera.main.orthographicSize;
            if (CameraSize > CameraStart)
            {
                Camera.main.orthographicSize -= 0.2f;
            }
        }
       
    }


    //The boss works on patterns, this is just a simple function which repeats the bosses attack patterns
    void SelectAbility()
    {
        if(Vector3.Distance(Player.transform.position,transform.position) < EngageRange)
        {
            counter += Time.deltaTime;
            if (counter >= StageTime)
            {
                counter = 0;
                switch (CurrentStage)
                {
                    case 0:
                        RainFire();
                        CurrentStage = 1f;
                        break;
                    case 1:
                        Swipe();
                        CurrentStage = 2f;
                        break;
                    case 2:
                        FireBalls();
                        CurrentStage = 0f;
                        break;
                }
            }
        }
       
      
    }

    // Update is called once per frame
    void Update()
    {
        SelectAbility();
    }
}
