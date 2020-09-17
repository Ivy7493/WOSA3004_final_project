using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostSlice : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    Player_motor PM;
    public float Speed;
    public float DamageScale;
    public float SlowPercent;
    public float SlowDuration;
    float Damage;
    Experience_Manager EM;
    Vector2 Dir;
    Rigidbody2D RB;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        EM = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>();
        Damage = DamageScale * EM.ReturnLevel();
        Vector3 Temp = (Player.transform.position - transform.position).normalized;
        Dir = new Vector2(Temp.x, Temp.y);
        RB = GetComponent<Rigidbody2D>();
        RB.velocity = Dir * Speed;
        PM = Player.GetComponent<Player_motor>();
        FixRotation();
    }

    void FixRotation()
    {
        Vector3 temp = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Player.transform.position - temp;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>().Damage(Damage);
                PM.SetPlayerSlow(SlowPercent, SlowDuration);
                Destroy(gameObject);
            }
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
