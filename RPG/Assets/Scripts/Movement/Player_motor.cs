using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Player_motor : MonoBehaviour
{
    // Start is called before the first frame update
    public float _speed;
    float DefaultSpeed;
    Rigidbody2D RB;
    AIPath PathControl;
    AIDestinationSetter Motor;
    Vector3 pos;
    GameObject StartTransform;
    GameObject CurrentTransform;
    Vector3 mousePosition;
    Vector2 direction;
    public GameObject Mouse_Effect;
    public GameObject DefaultSpawn;
    bool Slowed = false;
    private void Awake()
    {
        LoadPlayerPosition();
    }
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();  
        DefaultSpeed = _speed;
    }

    public void SetPlayerSlow(float SlowPercent, float time)
    {
        if(Slowed == false)
        {
            Slowed = true;
            float ActualSlow = 1 - SlowPercent;
            _speed = _speed * (ActualSlow);
            StartCoroutine(Slow(time));
        }
       
    }

    IEnumerator Slow(float time)
    {
        yield return new WaitForSeconds(time);
        _speed = DefaultSpeed;
        Slowed = false;
    }


    void LoadPlayerPosition()
    {
        float Xpos = PlayerPrefs.GetFloat("Xpos", DefaultSpawn.transform.position.x);
        float Ypos = PlayerPrefs.GetFloat("Ypos", DefaultSpawn.transform.position.y);
        transform.position = new Vector3(Xpos, Ypos, 0f);
    }


    void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat("Ypos", transform.position.y);
        PlayerPrefs.SetFloat("Xpos", transform.position.x);
    }



    void ClickMotion()
    {
        if((Input.GetMouseButtonDown(1)))
        {
           
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos = new Vector3(pos.x, pos.y, 0f);
            Instantiate(Mouse_Effect, pos, Quaternion.identity);
            if(RB.velocity.magnitude != 0)
            {
                RB.velocity = Vector2.zero;
            }
            Vector3 temp = (pos - transform.position ).normalized;
            direction = new Vector2(temp.x, temp.y) * _speed;
            RB.velocity = direction;

        }
        if (Input.GetKey(KeyCode.LeftShift)){
            RB.velocity = Vector2.zero;
        }

        if (Vector3.Distance(transform.position,pos) < 0.5f)
        {
            RB.velocity = Vector2.zero;
        }
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

    private void OnDestroy()
    {
        SavePlayerPosition();
    }

    private void OnApplicationQuit()
    {
        SavePlayerPosition();
    }

    // Update is called once per frame
    void Update()
    {
         Motion();
       // ClickMotion();
    }
}
