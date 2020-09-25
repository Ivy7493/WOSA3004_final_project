using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Exploder_AI : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    GameObject StartTransform;
    public float EngageRange;
    public float MaxRange;
    public float DamageScale;
    float PlayerLevel;
    float Damage;
    Transform StartPos;
    AIDestinationSetter Motor;
    Vector3 PreviousPosition;
    Vector3 CurrentPosition;
    Animator Anim;
    Enemy_Status ES;
    /// <summary>
    ///Start Transform 411
    ///okay so, we need to create an empty game object with a transform attached. That way we can spawn it at the start location of the enemy and have a reference to pass
    ///into the Motor which will then command the enemy back to its start location once it has exceeded its max range
    ///
    /// </summary>
    void Start()
    {
        //For some reason when spawning an enemy from a spawner, the transform_holder gets delinked, so we load it from resources if it does
        if (StartTransform == null)
        {
            StartTransform = Resources.Load("Transform_Holder", typeof(GameObject)) as GameObject;
        }
        GameObject TempStartPos = Instantiate(StartTransform, transform.position, Quaternion.identity);
        TempStartPos.GetComponent<Transform_Holder>().SetEnemy(gameObject);
        StartPos = TempStartPos.transform;
        Player = GameObject.FindGameObjectWithTag("Player");
        Motor = GetComponent<AIDestinationSetter>();
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        Damage = PlayerLevel * DamageScale;
        PreviousPosition = transform.position;
        Anim = GetComponentInChildren<Animator>();
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
       if(ES.ReturnStunStatus() == false)
        {
            if (Vector3.Distance(StartPos.position, transform.position) > MaxRange)
            {
                Motor.target = StartPos;
            }
            else if (Vector3.Distance(transform.position, Player.transform.position) <= EngageRange)
            {

                if (Player.transform != null)
                {

                    Motor.target = Player.transform;
                }

            }
            RunningAnimation();
        }
       

       
    }

    void RunningAnimation()
    {
        CurrentPosition = transform.position;
        if(Vector3.Distance(CurrentPosition,PreviousPosition) > 0.1)
        {
            Anim.SetBool("Running", true);
        }else if(Vector3.Distance(CurrentPosition, PreviousPosition) < 0.1)
        {
            Anim.SetBool("Running", false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>().Damage(Damage);
            Destroy(gameObject);

        }
       
    }
    //NB ALL AI NEED TO DESTORY THEIR START TRANSFORM WHEN THEY GET DESTORYED FOR SYSTEM RESOURCES
    private void OnDestroy()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
