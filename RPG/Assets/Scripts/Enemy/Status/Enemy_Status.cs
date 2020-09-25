using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_Status : MonoBehaviour
{
    // Start is called before the first frame update
    AIPath Motor;
    bool Slowed = false;
    bool Stunned = false;
    float DefaultSpeed = 0f;
    UI_Manager UIM;

    void Start()
    {
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        try
        {
            Motor = GetComponent<AIPath>();
            DefaultSpeed = Motor.maxSpeed;
        }
        catch
        {
            Debug.Log("Enemy Status, no motor" + gameObject.name);
        }
    }

    public void SetEnemySlow(float SlowPercent, float time)
    {
        Debug.Log("Layer 1");
        if (Slowed == false)
        {
            Debug.Log("Layer 2");
            Slowed = true;
            float ActualSlow = 1 - SlowPercent;
            Motor.maxSpeed = Motor.maxSpeed * (ActualSlow);
            
            UIM.SpawnStatusText(transform.position, "Slowed");
            StartCoroutine(Slow(time));
        }

    }

    public void SetEnemyStun(float time)
    {
        if(Stunned == false)
        {
            Stunned = true;
            UIM.SpawnStatusText(transform.position, "Stunned");
            StartCoroutine(Stun(time));
        }
    }

    public bool ReturnStunStatus()
    {
        return Stunned;
    }

    IEnumerator Stun(float time)
    {
        Motor.canMove = false;
        yield return new WaitForSeconds(time);
        if(Motor != null)
        {
            Motor.canMove = true;
        }
        Stunned = false;
    }

    IEnumerator Slow(float time)
    {
        yield return new WaitForSeconds(time);
        if(Motor != null)
        {
            Motor.maxSpeed = DefaultSpeed;
        }
      
        Slowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
