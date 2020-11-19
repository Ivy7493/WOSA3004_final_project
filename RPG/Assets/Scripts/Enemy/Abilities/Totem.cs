using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    // Start is called before the first frame update
    public float DamageScale;
    public float TickRate;
    public float Duration;
    public float AttackRange;
    public float SlowPercent;
    public float SlowDuration;
    float Damage;
    GameObject Player;
    Resource_Manager RM;
    Player_motor PM;
    LineRenderer LR;
    Enemy_Health EH;
    float counter = 0;
    Color32 StartColor;
    Color32 EndColor;
    void Start()
    {
        Damage = DamageScale * GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        Player = GameObject.FindGameObjectWithTag("Player");
        RM = GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>();
        LR = GetComponent<LineRenderer>();
        LR.material.SetColor("_color", Color.grey);
        InvokeRepeating("Spell", 0f, TickRate);
        StartColor = LR.startColor;
        EndColor = LR.endColor;
        PM = Player.GetComponent<Player_motor>();
        EH = GetComponent<Enemy_Health>();
    }

    void Spell()
    {
        if(Vector3.Distance(Player.transform.position,transform.position) <= AttackRange)
        {
            RM.Damage(Damage);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("DEDO ON DEDO");
    }

    // Update is called once per frame
    void Update()
    {
        if(EH.ReturnCurrentHealth() >= 0)
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <= AttackRange)
            {
                LR.startColor = StartColor;
                LR.endColor = EndColor;
                LR.SetPosition(1, new Vector3(transform.position.x, transform.position.y, -1f));
                LR.SetPosition(0, new Vector3(Player.transform.position.x, Player.transform.position.y, -1));
                PM.SetPlayerSlow(SlowPercent, SlowDuration);
            }
            else
            {
                LR.startColor = Color.clear;
                LR.endColor = Color.clear;
                LR.SetPosition(1, Vector3.one);
                LR.SetPosition(0, Vector3.one);
            }
            counter += Time.deltaTime;
            if (counter >= Duration)
            {
                Destroy(gameObject);
            }
        }
       
    }
}
