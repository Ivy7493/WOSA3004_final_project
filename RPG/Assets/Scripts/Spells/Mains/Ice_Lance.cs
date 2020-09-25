using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Lance : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    Vector3 pos;
    Vector3 CurrenPos;
    Vector3 Direction;
    public float Range;
    public float Speed;
    public float SlowPercent;
    public float SlowDuration;
    public float DamageScale;
    float Damage;
    float PlayerLevel;
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0f);
        CurrenPos = transform.position;
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        Damage = DamageScale * PlayerLevel;
        Direction = (pos - Player.transform.position).normalized;
        FixRotation();


    }

    void FixRotation()
    {
        Vector3 temp = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - temp;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Motion()
    {

        transform.position += Direction * Speed * Time.deltaTime;
        DistanceCheck();

    }

    void DistanceCheck()
    {
        if (Vector3.Distance(CurrenPos, transform.position) >= Range)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damagable")
        {
            if (collision.gameObject.GetComponent<Enemy_Health>() != null)
            {
                collision.gameObject.GetComponent<Enemy_Health>().Damage(Damage);

            }
            try
            {
                collision.gameObject.GetComponent<Enemy_Status>().SetEnemySlow(SlowPercent, SlowDuration);
            }
            catch
            {

            }
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Motion();
    }
}
