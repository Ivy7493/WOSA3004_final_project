﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Frost_Shaman_AI : MonoBehaviour
{
    // Start is called before the first frame update
    Transform StartPos;
    GameObject StartTransform;
    public float MaxRange;
    public float EngageRange;
    public float TotemReplaceTime;
    public float KiteDistance;
    public GameObject Totem;
    GameObject Player;
    AIDestinationSetter Motor;
    AIPath PathControl;
    Resource_Manager RM;
    float counter = 0f;
    GameObject CurrentTotem;
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
        RM = GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>();
        PathControl = GetComponent<AIPath>();

        if (StartPos == null)
        {
            Debug.Log("Its The StartPos");
        }
    }

    void Movement()
    {
        if (Vector3.Distance(StartPos.position, transform.position) > MaxRange)
        {
            if (transform.position == StartPos.transform.position)
            {
                Motor.target = null;
                PathControl.canMove = false;
            }
            else
            {
                PathControl.canMove = true;
                Motor.target = StartPos;
            }

        }
        else if (Vector3.Distance(transform.position, Player.transform.position) <= EngageRange)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) > KiteDistance)
            {
                PathControl.canMove = true;
                if (Player.transform != null)
                {
                    Motor.target = Player.transform;
                }
            }
            else if (Vector3.Distance(transform.position, Player.transform.position) < KiteDistance)
            {
                PathControl.canMove = true;
                Motor.target = StartPos;
            }
            else
            {
                Motor.target = null;
                PathControl.canMove = false;
            }


        }
    }

    void Encounter()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) <= EngageRange)
        {
            counter += Time.deltaTime;
            if (counter >= TotemReplaceTime)
            {
                counter = 0;
                Vector3 TempLocation1 = new Vector3(Player.transform.position.x, Player.transform.position.y, 0f);
                Vector3 TempLocation2 = new Vector3(transform.position.x, transform.position.y, 0f);
                Vector3 result = (TempLocation2 - TempLocation1).normalized * 1f;
                result = (Player.transform.position + transform.position)/2;
                if(CurrentTotem != null)
                {
                    Destroy(CurrentTotem);
                }
               CurrentTotem = Instantiate(Totem, result, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Encounter();
    }
}