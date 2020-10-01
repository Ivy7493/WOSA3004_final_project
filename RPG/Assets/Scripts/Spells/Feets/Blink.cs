using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    public float Distance;
    public float Speed;
    public float DashTime;
    float counter = 0f;
    Rigidbody2D RB;
    public GameObject BlinkEffect;
    Vector2 DashDirection;
    public bool isBlinking = false;
    SpriteRenderer[] PlayerGraphics;
    Player_motor PM;
    Vector3 StartPos;
    Player_Graphics PG;
    GameObject PlayerGraphic;
    Resource_Manager RM;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            RB = Player.GetComponent<Rigidbody2D>();
            PlayerGraphic = GameObject.FindGameObjectWithTag("Player_Graphics");
        }
        RM = GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>();
        PlayerGraphic.transform.localPosition = new Vector3(1000f, 1000f, 0f);
        PlayerGraphics = Player.GetComponentsInChildren<SpriteRenderer>();
        PM = Player.GetComponent<Player_motor>();
        PG = Player.GetComponentInChildren<Player_Graphics>();
        StartPos = Player.transform.position;
         NewBlink();
       
    }


    


    void NewBlink()
    {
        isBlinking = true;
        Vector3 pos;
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0f);
        Vector3 Direction = (pos - Player.transform.position).normalized;
        float Xpos = Input.GetAxisRaw("Horizontal");
        float Ypos = Input.GetAxisRaw("Vertical");
        DashDirection = new Vector2(Xpos, Ypos);
        RB.velocity = DashDirection * Speed;
        GetComponent<SpriteRenderer>().material.SetVector("_Direction", DashDirection);
        GetComponent<SpriteRenderer>().material.SetFloat("_Speed", 3);
        RM.SetGodModeOn();
     
    }

    void EndBlink()
    {
        counter += Time.deltaTime;
       
        if(counter >= DashTime)
        {
            RB.velocity = Vector2.zero;
            PlayerGraphic.transform.localPosition = Vector3.zero;
            RM.SetGodModeOff();
            Destroy(gameObject);
        }
    }

    public bool ReturnIsBlinking()
    {
        return isBlinking;
    }

    void blink()
    {
        float Xpos = Input.GetAxisRaw("Horizontal");
        float Ypos = Input.GetAxisRaw("Vertical");
        Vector3 Motion = new Vector3(Xpos, Ypos, 0f);
        Motion *= Distance;
        Instantiate(BlinkEffect, Player.transform.position, Quaternion.identity);
        Player.transform.position += Motion;
    //    Instantiate(BlinkEffect, Player.transform.position, Quaternion.identity);
        Debug.Log("Cast: Blink");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        EndBlink();
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed);
        float angle = Mathf.Atan2(DashDirection.y, DashDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
}
