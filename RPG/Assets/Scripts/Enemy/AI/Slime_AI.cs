using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Slime_AI : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxRange;
    public float EngageRange;
    public float AttackSpeed;
    public float DamageScale;
    public float AttackRange;
    float counter = 0f;
    float Damage;
    GameObject Player;
    AIDestinationSetter Motor;
    Resource_Manager RM;
    GameObject StartTransform;
    Transform StartPos;
    Vector3 PreviousPosition;
    Enemy_Health EH;
    public GameObject Slime;
    public bool Recursion;
    void Start()
    {
        if (StartTransform == null)
        {
            StartTransform = Resources.Load("Transform_Holder", typeof(GameObject)) as GameObject;
        }
        GameObject TempStartPos = Instantiate(StartTransform, transform.position, Quaternion.identity);
        TempStartPos.GetComponent<Transform_Holder>().SetEnemy(gameObject);
        StartPos = TempStartPos.transform;
        Player = GameObject.FindGameObjectWithTag("Player");
        Motor = GetComponent<AIDestinationSetter>();
        Damage = DamageScale * GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        RM = GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>();
        PreviousPosition = transform.position;
        EH = GetComponent<Enemy_Health>();
    }

    void Animations()
    {
        if(Mathf.Abs(Vector3.Distance(transform.position,PreviousPosition)) > 0.5f)
        {
            //Put running animation;
        }else if (Mathf.Abs(Vector3.Distance(transform.position, PreviousPosition)) < 0.5f)
        {
            // put idle animation here
        }
    }

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
                Debug.Log("Getting here Silly!");
                Motor.target = Player.transform;
            }

        }
    }


    void Encounter()
    {
       
        counter += Time.deltaTime;
        if(Vector3.Distance(Player.transform.position,transform.position) <= AttackRange && counter >= AttackSpeed)
        {
            // put Attack Animation here
            RM.Damage(Damage);
            counter = 0f;
        }
    }

    private void OnDestroy()
    {
        if (EH.ReturnCurrentHealth() <= 0 && Recursion == true)
        {
            GameObject Slime1 = Instantiate(Slime, transform.position, Quaternion.identity);
            GameObject Slime2 = Instantiate(Slime, transform.position, Quaternion.identity);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Animations();
        Encounter();
    }
}
