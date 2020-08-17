using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning_bolt : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    LineRenderer LR;
    Vector3 pos;
    Vector3 CurrenPos;
    public float Range;
    public float Speed;
    public float Damage;
    void Start()
    {
        LR = GetComponent<LineRenderer>();
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0f);
        CurrenPos = transform.position;
        LR.SetPosition(1, Player.transform.position);
        LR.SetPosition(0, pos);

    }

    void Motion()
    {
        LR.SetPosition(1, Player.transform.position);
        LR.SetPosition(0, pos);
        if (Vector3.Distance(transform.position,pos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, Speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Damagable")
        {
            Debug.Log("Hit " + collision.gameObject.name + "!");
            if(collision.gameObject.GetComponent<Enemy_Health>() != null)
            {
                collision.gameObject.GetComponent<Enemy_Health>().Damage(Damage);
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        Motion();
    }
}
