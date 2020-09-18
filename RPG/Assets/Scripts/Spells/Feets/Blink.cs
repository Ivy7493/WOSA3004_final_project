using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    public GameObject BlinkEffect;
    public float Distance;
    public float Speed;
    public float DashTime;
    float counter = 0f;
    Rigidbody2D RB;
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            RB = Player.GetComponent<Rigidbody2D>();
        }
        // blink();
        NewBlink();
    }


    void NewBlink()
    {
        Vector3 pos;
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0f);
        Vector3 Direction = (pos - Player.transform.position).normalized;
        float Xpos = Input.GetAxisRaw("Horizontal");
        float Ypos = Input.GetAxisRaw("Vertical");
        Vector2 DashDirection = new Vector2(Direction.x, Direction.y);
        RB.velocity = DashDirection * Speed;
    }

    void EndBlink()
    {
        counter += Time.deltaTime;
        if(counter >= DashTime)
        {
            RB.velocity = Vector2.zero;
            Destroy(gameObject);
        }
    }

    void blink()
    {
        float Xpos = Input.GetAxisRaw("Horizontal");
        float Ypos = Input.GetAxisRaw("Vertical");
        Vector3 Motion = new Vector3(Xpos, Ypos, 0f);
        Motion *= Distance;
        Instantiate(BlinkEffect, Player.transform.position, Quaternion.identity);
        Player.transform.position += Motion;
        Instantiate(BlinkEffect, Player.transform.position, Quaternion.identity);
        Debug.Log("Cast: Blink");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        EndBlink();
    }
}
