using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcane_Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public float Range;
    public float Speed;
    public float DamageScale;
    float Damage;
    GameObject Player;
    SpriteRenderer SR;
    float counter = 0f;
    void Start()
    {
        Damage = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel() * DamageScale;
        SR = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    void Spell()
    {
        transform.position = Player.transform.position;
        counter += Time.deltaTime*2;
        transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(Range * 2, Range * 2, 1f), counter);
        if(counter*Speed >= 1)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damagable")
        {
            try
            {
                collision.gameObject.GetComponent<Enemy_Health>().Damage(Damage);
            }
            catch
            {
                Debug.Log("Enemy_Health component not found!");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Spell();
    }
}
