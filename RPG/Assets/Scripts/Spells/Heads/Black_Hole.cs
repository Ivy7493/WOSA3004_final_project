using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Hole : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 pos;
    public float Duration;
    public float Range;
    public float PullStrength;
    float counter;
    GameObject[] Enemies;
    void Start()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0f);
        transform.position = pos;
        Enemies = GameObject.FindGameObjectsWithTag("Damagable");
        Spell();
    }

    void Spell()
    {
       
        for(int i = 0; i < Enemies.Length; i++)
        {
            if (Vector3.Distance(transform.position, Enemies[i].transform.position) < Range)
            {
                Vector3 Direction = (transform.position - Enemies[i].transform.position).normalized;
                try
                {
                    
                    Enemies[i].transform.position += Direction * PullStrength * Time.deltaTime;
                }
                catch
                {
                    Debug.Log("Couldn't find rigidbody for " + i);
                }
            }
           
        }
    }


    private void OnDestroy()
    {
        for(int i = 0; i < Enemies.Length; i++)
        {
            if(Enemies[i] != null)
            {
                if (Vector3.Distance(transform.position, Enemies[i].transform.position) < Range)
                {
                    try
                    {
                        Enemies[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    }
                    catch
                    {
                        Debug.Log("Couldn't find rigidbody for " + i);
                    }
                }
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        Spell();
        counter += Time.deltaTime;
        if(counter >= Duration)
        {
            Destroy(gameObject);
        }
    }
}
