using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Frost_Giant_AI : MonoBehaviour
{
    // Start is called before the first frame update
    Transform StartPos;
    GameObject StartTransform;
    public float MaxRange;
    public float EngageRange;
    public float AttackFrequency;
    public float AttackRange;
    public float DamageScale;
    GameObject Player;
    AIDestinationSetter Motor;
    AIPath PathControl;
    Resource_Manager RM;
    Experience_Manager EM;
    Enemy_Health EH;
    float counter = 0f;
    float Damage;
    public float EnrageThresold;
    public float EnrageHealthLose;
    bool enraged = false;
    Enemy_Status ES;
    void Start()
    {
        if (StartTransform == null)
        {
            StartTransform = Resources.Load("Transform_Holder", typeof(GameObject)) as GameObject;
        }
        GameObject TempStartPos = Instantiate(StartTransform, transform.position, Quaternion.identity);
        EM = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>();
        TempStartPos.GetComponent<Transform_Holder>().SetEnemy(gameObject);
        StartPos = TempStartPos.transform;
        Player = GameObject.FindGameObjectWithTag("Player");
        Motor = GetComponent<AIDestinationSetter>();
        RM = GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>();
        PathControl = GetComponent<AIPath>();
        EH = GetComponent<Enemy_Health>();
        try
        {
            ES = GetComponent<Enemy_Status>();
        }
        catch
        {

        }

    }

    //Movement Control for AI and engage range
    //At max range will move back to spawn location
    // AT engage range will engage the player
    void Movement()
    {
        if (Vector3.Distance(StartPos.position, transform.position) > MaxRange)
        {
            if (transform.position == StartPos.transform.position)
            {
                Motor.target = null;
            }
            else
            {
                Motor.target = StartPos;
            }

        }
        else if (Vector3.Distance(transform.position, Player.transform.position) <= EngageRange)
        {
            if (Player.transform != null)
            {
                Motor.target = Player.transform;
            }

        }
    }

    void Enrage()
    {
        if(EH.ReturnCurrentHealthPercent() < EnrageThresold && enraged == false)
        {
            enraged = true;
            AttackFrequency /= 3;
            PathControl.maxSpeed *= 5;
        }else if(enraged == true)
        {
            EH.Damage(EH.ReturnMaxHealth() * EnrageHealthLose * Time.deltaTime);
        }
    }

    void Encounter()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) <= EngageRange)
        {
            counter += Time.deltaTime;
            if (counter >= AttackFrequency)
            {
               

                if (Vector3.Distance(transform.position, Player.transform.position) <= AttackRange)
                {
                    Damage = DamageScale * EM.ReturnLevel();
                    if(enraged == false)
                    {
                        RM.Damage(Damage);
                    }else if(enraged == true)
                    {
                        RM.Damage(Damage * 2);
                    }
                    
                    counter = 0f;

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ES.ReturnStunStatus() == false)
        {
            Movement();
            Encounter();
            Enrage();
        }
      
       
    }
}
