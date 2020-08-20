using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Boss_AI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] FireLocations;
    public GameObject FireBombs;
    GameObject Player;
    float CurrentStage = 0;
    float counter = 0f;
    public float StageTime;
    public float EngageRange;
    public float CameraZoom;
    public float SwipeRange;
    public float SwipeDamageScale;
    float CameraStart;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        CameraStart = Camera.main.orthographicSize;
        InvokeRepeating("CameraProspective", 0, 0.1f);
    }


    void RainFire()
    {
        float Select = Random.Range(0, FireLocations.Length);
        for(int i = 0; i <= Select; i++)
        {
            Instantiate(FireBombs, FireLocations[i].transform.position, Quaternion.identity);
        }

    }

    void Swipe()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) < SwipeRange)
        {
            float Damage = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel() * SwipeDamageScale;
            GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>().Damage(Damage);
        }
    }

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
