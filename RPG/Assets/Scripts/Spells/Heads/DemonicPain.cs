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
    public float SpreadRange;
    float Damage;
    bool CanSpead = true;
    float counter = 0f;
    GameObject Target;
    Vector3 pos;
    
    void Start()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0f);
        transform.position = pos;
        Damage = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel() * DamageScale;
        if(CanSpead == true)
        {
            Setup();
        }
       
        InvokeRepeating("Spell", TickRate, TickRate);
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

    public void OverrideTarget(GameObject _Target)
    {
        Target = _Target;
        CanSpead = false;
        counter = 0f;
        StartCoroutine(Retarget(_Target));
    }

    IEnumerator Retarget(GameObject _Target)
    {
        yield return new WaitForSeconds(0.2f);
        Target = _Target;
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

        try
        {
            if(CanSpead == true)
            {
                GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Damagable");
                for (int i = 0; i < Enemies.Length; i++)
                {
                    if (Vector3.Distance(Target.transform.position, Enemies[i].transform.position) < SpreadRange && Target != Enemies[i])
                    {
                        Debug.Log("So we here which means its the prefab");
                        GameObject NewSpread = Instantiate(gameObject, Enemies[i].transform.position, Quaternion.identity);
                        NewSpread.GetComponent<DemonicPain>().OverrideTarget(Enemies[i]);

                    }
                }
            }
            

        }
        catch
        {
            Debug.Log("PPPPOOOOOOOO");
        }
    }

    void Rotation()
    {
        transform.Rotate(new Vector3(0f, 0f, 90 * Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        counter += Time.deltaTime;
        if(Target != null)
        {
            transform.position = Target.transform.position;
        }
       
        if (counter >= Duration || Target == null)
        {
            Destroy(gameObject);
        }
    }
}
