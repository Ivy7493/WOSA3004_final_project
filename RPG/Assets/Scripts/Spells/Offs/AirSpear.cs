using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSpear : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    public float Speed;
    public float DamageScale;
    float Damage;
    float DeltaOff = 2;
    Vector3 pos;
    void Start()
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
    }

    void Spell()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, Speed *Time.deltaTime);
        if(Mathf.Abs(Vector3.Distance(transform.position,pos) ) < 0.1)
        {
            Destroy(gameObject);
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
            Vector3 offset = collision.gameObject.transform.position - Player.transform.position;
            offset = offset.normalized;
            Player.transform.position = new Vector3(collision.gameObject.transform.position.x - offset.x * DeltaOff, collision.gameObject.transform.position.y - offset.y * DeltaOff, 0f);
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
        Spell();
    }
}
