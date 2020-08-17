using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Flamer_AI : MonoBehaviour
{
    // Start is called before the first frame update
    Transform StartPos;
    GameObject StartTransform;
    public float MaxRange;
    public float EngageRange;
    public float AbilityFrequency;
    public float AttackRange;
    public GameObject Ability;
    GameObject Player;
    AIDestinationSetter Motor;
    float counter;
    /// <summary>
    ///Start Transform 411
    ///okay so, we need to create an empty game object with a transform attached. That way we can spawn it at the start location of the enemy and have a reference to pass
    ///into the Motor which will then command the enemy back to its start location once it has exceeded its max range
    ///
    /// </summary>
    void Start()
    {
        //For some reason when spawning an enemy from a spawner, the transform_holder gets delinked, so we load it from resources if it does
        if(StartTransform == null)
        {
            StartTransform = Resources.Load("Transform_Holder", typeof(GameObject)) as GameObject;
        }
        GameObject TempStartPos = Instantiate(StartTransform, transform.position, Quaternion.identity);
        TempStartPos.GetComponent<Transform_Holder>().SetEnemy(gameObject);
        StartPos = TempStartPos.transform;
        Player = GameObject.FindGameObjectWithTag("Player");
        Motor = GetComponent<AIDestinationSetter>();
    }

   
    //Movement Control for AI and engage range
    //At max range will move back to spawn location
    // AT engage range will engage the player
    void Movement()
    {
        if(Vector3.Distance(StartPos.position,transform.position) > MaxRange)
        {
            if(transform.position == StartPos.transform.position)
            {
                Motor.target = null;
            }
            else
            {
                Motor.target = StartPos;
            }
            
        }else if(Vector3.Distance(transform.position,Player.transform.position) <= EngageRange)
        {
            if(Player.transform != null)
            {
                Motor.target = Player.transform;
            }
            
        }
    }

    //Encounter is where the enmies does its moves
    void Encounter()
    {
        
        if(Vector3.Distance(transform.position, Player.transform.position) <= EngageRange)
        {
            counter += Time.deltaTime;
            if(counter >= AbilityFrequency)
            {
                counter = 0;
                Instantiate(Ability, transform.position, Quaternion.identity);
            }
        }

        if(Vector3.Distance(transform.position, Player.transform.position) <= AttackRange)
        {

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
        Encounter();
    }
}
