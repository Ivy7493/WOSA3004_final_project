using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_motor : MonoBehaviour
{
    // Start is called before the first frame update
    public float _speed;
    Rigidbody2D RB;
    private void Awake()
    {
        LoadPlayerPosition();
    }
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }


    void LoadPlayerPosition()
    {
        float Xpos = PlayerPrefs.GetFloat("Xpos", 0);
        float Ypos = PlayerPrefs.GetFloat("Ypos", 0);
        transform.position = new Vector3(Xpos, Ypos, 0f);
    }


    void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat("Ypos", transform.position.y);
        PlayerPrefs.SetFloat("Xpos", transform.position.x);
    }



    void Motion()
    {
        float Xpos = Input.GetAxisRaw("Horizontal");
        float Ypos = Input.GetAxisRaw("Vertical");
        Vector3 Direction = new Vector3(Xpos, Ypos, 0f);
        Direction *= _speed * Time.deltaTime;
        transform.position += Direction;
        if(RB.velocity.magnitude <= 10)
        {
            RB.velocity = Vector2.zero;
          //Testing
        }
    }

    
    //SO if an enemy projectile hits us it wont apply a force
    private void OnCollisionEnter2D(Collision2D collision)
    {
        RB.velocity = Vector2.zero;
    }

    private void OnApplicationQuit()
    {
        SavePlayerPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Motion();
    }
}
