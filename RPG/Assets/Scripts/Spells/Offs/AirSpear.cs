using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSpear : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    public float Speed;
    public float DamageScale;
    public float ChargeTime;
    public float StunDuration;
    public float Range;
    float Damage;
    float DeltaOff = 2;
    Vector3 pos;
    SpriteRenderer SR;
    float WindUp;
    bool casted = false;
    bool released = false;
    Vector3 StartPos;
    Vector3 Direction;
    UI_Manager UIM;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
    }

    void Setup()
    {
        Damage = DamageScale * GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        transform.position = Player.transform.position;
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0f);
        FixRotation();
        StartPos = transform.position;
        Direction = Direction = (pos - Player.transform.position).normalized;
    }

    void ActivateSpell()
    {
        if (Input.GetMouseButton(1) && released == false)
        {
            SR.color = Color.Lerp(Color.white, Color.yellow, WindUp/ChargeTime);
            WindUp += Time.deltaTime;
            Setup();
            UIM.SetCastBar(WindUp / ChargeTime);
            if (WindUp >= ChargeTime)
            {
                if(casted == false)
                {
                    SR.color = Color.red;
                    casted = true;
                }
            }
        }else if(Input.GetMouseButtonUp(1) && WindUp < ChargeTime)
        {
            UIM.SetCastBarOff();
            Destroy(gameObject);
            
        }else if(Input.GetMouseButtonUp(1) && WindUp >= ChargeTime)
        {
            released = true;
            
        }
    }

    void Spell()
    {
        if(casted == true)
        {
            transform.position += Direction * Speed * Time.deltaTime;
            if (Mathf.Abs(Vector3.Distance(transform.position, StartPos)) >= Range)
            {
                Destroy(gameObject);
            }
        }
       
    }

    void FixRotation()
    {
        Vector3 temp = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - temp;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Damagable")
        {
          
            try
            {
                collision.gameObject.GetComponent<Enemy_Health>().Damage(Damage);
              
            }
            catch
            {
                Debug.Log("Enemy_Health component not found!");
            }
            try
            {
                collision.gameObject.GetComponent<Enemy_Status>().SetEnemyStun(StunDuration);
            }
            catch
            {
                Debug.Log("Enemy is immune to status effects");
            }
            
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ActivateSpell();
        Spell();
    }
}
