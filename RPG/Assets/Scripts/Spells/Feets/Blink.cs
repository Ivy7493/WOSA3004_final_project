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
    public Material BlinkEffect;
    Material DefaultMaterial;
    public bool isBlinking = false;
    SpriteRenderer[] PlayerGraphics;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            RB = Player.GetComponent<Rigidbody2D>();
        }
        // blink();
        PlayerGraphics = Player.GetComponentsInChildren<SpriteRenderer>();
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
        Vector2 DashDirection = new Vector2(Xpos, Ypos);
        RB.velocity = DashDirection * Speed;
        DefaultMaterial = PlayerGraphics[0].material;
        for(int i = 0; i < PlayerGraphics.Length; i++)
        {
            PlayerGraphics[i].material = BlinkEffect;
            PlayerGraphics[i].material.SetVector("_Direction", DashDirection);
            PlayerGraphics[i].material.SetFloat("_Speed", Speed);
        }
    }

    void EndBlink()
    {
        counter += Time.deltaTime;
        if(counter >= DashTime)
        {
            RB.velocity = Vector2.zero;
            isBlinking = false;
            for (int i = 0; i < PlayerGraphics.Length; i++)
            {
                PlayerGraphics[i].material = DefaultMaterial;
               
            }
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
    }
}
