using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Shear : MonoBehaviour
{
    // Start is called before the first frame update
    public float DamageScale;
    public float Speed;
    public float Range;
    Vector3 pos;
    Vector3 StartPos;
    Vector3 Direction;
    GameObject Player;
    Sound_Manager SM;
    public float KnockBack;
    public AudioClip Sound;

    float Damage;
   
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        SM = GameObject.FindGameObjectWithTag("Sound_Manager").GetComponent<Sound_Manager>();
        SM.PlaySound(Sound);
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0f);
        Damage = DamageScale * GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        Direction = (pos - Player.transform.position).normalized;
        StartPos = transform.position;
        FixRotation();
        Spell();
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
        transform.position += Direction * Speed * Time.deltaTime;
        DistanceCheck();
    }

    IEnumerator KnockBackEffect(float Duration, GameObject Target)
    {
      Target.gameObject.transform.position += ((Target.gameObject.transform.position - StartPos).normalized * (KnockBack*Time.deltaTime));
        yield return new WaitForSeconds(Duration);
        Destroy(gameObject);
    }

    void DistanceCheck()
    {
        if (Vector3.Distance(StartPos, transform.position) >= Range)
        {
            Destroy(gameObject);
        }
    }

    void RotationFunction()
    {
        transform.Rotate(0f, 0f, 360 * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Damagable")
        {
            try
            {
                collision.gameObject.GetComponent<Enemy_Health>().Damage(Damage);

                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(KnockBackEffect(1f,collision.gameObject));
              
                Destroy(gameObject);
            }
            catch
            {
                Debug.Log("No, Enemy Health componenet found");
            }
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Spell();
        RotationFunction();
      
    }
}
