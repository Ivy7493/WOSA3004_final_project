using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonicPain : MonoBehaviour
{
    // Start is called before the first frame update
    public float DamageScale;
    public float TickRate;
    public float Duration;
    public float Range;
    float Damage;
    GameObject Target;
    Vector3 pos;
    void Start()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0f);
        transform.position = pos;
        Damage = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel() * DamageScale;
        Setup();
        InvokeRepeating("Spell", 0f, TickRate);
    }

    void Setup()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Damagable");
        float TempDist = 1000f;
        int CurrentIndex = -1;
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (Vector3.Distance(transform.position, Enemies[i].transform.position) < TempDist && Vector3.Distance(transform.position, Enemies[i].transform.position) < Range)
            {
                TempDist = Vector3.Distance(transform.position, Enemies[i].transform.position);
                CurrentIndex = i;
            }
        }
        if(CurrentIndex != -1)
        {
            Target = Enemies[CurrentIndex];
            transform.position = Target.transform.position;
        }
       
    }

    void Spell()
    {
        try
        {
            if(Target != null)
            {
                Target.GetComponent<Enemy_Health>().Damage(Damage);
            }
            
        }
        catch
        {
            Debug.Log("No Enemy Health Component found");
        }
    }

    void Rotation()
    {
        transform.Rotate(new Vector3(0f, 0f, 360 * Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        Duration -= Time.deltaTime;
        if(Target != null)
        {
            transform.position = Target.transform.position;
        }
       
        if (Duration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
