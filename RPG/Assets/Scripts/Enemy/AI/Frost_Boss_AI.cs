using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frost_Boss_AI : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    Game_Manager GM;
    Enemy_Health EH;
    Music_Manager MM;
    Animator Anim;
    float CameraStart;
    public GameObject FrostSlice;
    public GameObject FrostRainAbility;
    public GameObject TotemFieldAbility;
    public GameObject[] Location;
    public GameObject TotemCenter;
    public GameObject Key;
    GameObject CurrentTotem;
    Vector3 StartPos;
    public float StageTime;
    public float EngageRange;
    float CurrentStage = 1f;
    float counter = 0f;
    float status;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
        EH = GetComponent<Enemy_Health>();
        Anim = GetComponentInChildren<Animator>();
        status = GM.ReturnBossStatus("FROST");
        CameraStart = Camera.main.orthographicSize;
        StartPos = transform.position;
        CheckBossStatus();


    }

    void CheckBossStatus()
    {
        if (status == 1)
        {
            //Destroy(GameObject.FindGameObjectWithTag("FireBoss_SoundPoint"));
            Destroy(gameObject);
        }
    }

    void CheckHealth()
    {
        if (EH.ReturnCurrentHealth() <= 0)
        {
            Instantiate(Key, transform.position, Quaternion.identity);
           // MM.PlayFireArea();
           //Destroy(GameObject.FindGameObjectWithTag("FireBoss_SoundPoint"));
        }
    }

    private void OnDestroy()
    {
        if (status == 1)
        {

        }
        else if (status == 0)
        {
            CheckHealth();
        }
        try
        {
            Camera.main.orthographicSize = CameraStart;
        }
        catch
        {
            Debug.Log("Caught camera issue");
        }

    }


    void FrostRain()
    {
        Instantiate(FrostRainAbility, transform.position, Quaternion.identity);
    }

    void TotemField()
    {
        if(CurrentTotem == null)
        {
            CurrentTotem = Instantiate(TotemFieldAbility, Player.transform.position, Quaternion.identity);
        }
      
    }

    void Slice()
    {
      for(int i = 0; i < Location.Length; i++)
        {
            Instantiate(FrostSlice, Location[i].transform.position, Quaternion.identity);
        }
    }

    void SelectAbility()
    {
        if(Vector3.Distance(transform.position,Player.transform.position) <= EngageRange)
        {
            counter += Time.deltaTime;
            if(counter > StageTime)
            {
                counter = 0f;
                switch (CurrentStage)
                {
                    case 1:
                        CurrentStage = 2f;
                        Anim.SetTrigger("Blast");
                        Slice();
                        break;
                    case 2:
                        CurrentStage = 3f;
                        FrostRain();
                        Anim.SetTrigger("Smash");
                        break;
                    case 3:
                        CurrentStage = 1f;
                        TotemField();
                        Anim.SetTrigger("Conjure");
                        break;
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        SelectAbility();
        transform.position = StartPos;
    }
}
