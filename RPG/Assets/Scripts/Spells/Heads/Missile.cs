using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
    float Damage;
    float Range;
    float Speed;
    float counter;
    Vector3 pos;
    Vector3 Direction;
    Vector3 StartPos;
    GameObject Player;
    bool Set = false;
    bool Phase = false;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0f);
        Direction = (pos - transform.position).normalized;
        StartPos = transform.position;
       
       // FixRotation();
    }

    public void SetValues(float _damage, float _range, float _speed)
    {
        Damage = _damage;
        Range = _range;
        Speed = _speed;
        Set = true;
    }

    void FixRotation()
    {
        Vector3 temp = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - temp;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Spell()
    {
        counter += Time.deltaTime;
        float Ypos = 2 * Mathf.Sin(5*counter);
        float Xpos = 2 * Mathf.Cos(5*counter);
        if(Phase == false)
        {
            transform.position = new Vector3(Player.transform.position.x+Xpos,Player.transform.position.y+Ypos,0f);
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Damagable");
            for(int i = 0; i < Enemies.Length; i++)
            {
                if(Vector3.Distance(transform.position,Enemies[i].transform.position) < Range)
                {
                    Phase = true;
                    Direction = (Enemies[i].transform.position - transform.position).normalized;
                }
            }
        }
        if(Phase == true)
        {
              transform.position += new Vector3(Direction.x ,Direction.y ,0f)* Speed * Time.deltaTime;
        }

        if (Vector3.Distance(Player.transform.position,transform.position) >= Range)
        {
            Destroy(gameObject);
        }
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
           

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Set == true)
        {
           
            Spell();
        }
      
    }
}
