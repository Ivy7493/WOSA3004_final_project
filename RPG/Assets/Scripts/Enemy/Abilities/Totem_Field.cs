using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem_Field : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Totems;
    float counter = 0f;
    int currentIndex = 0;
    LineRenderer LR;
    GameObject Player;
    public float DamageScale;
    float Damage;
    void Start()
    {
        LR = GetComponent<LineRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < 6; i++)
        {
            LR.SetPosition(i, transform.position);
        }
        LR.material.SetColor("_color", Color.blue);

        Damage = DamageScale * GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();

    }


    void Effect()
    {
        counter += Time.deltaTime;
        if (counter >= 0.2f && currentIndex < Totems.Length)
        {
            counter = 0f;
            try
            {
                LR.SetPosition(currentIndex, new Vector3(Totems[currentIndex].transform.position.x, Totems[currentIndex].transform.position.y, -1f));
            }
            catch
            {

            }

            currentIndex++;


        }
        if (currentIndex == Totems.Length - 1)
        {
            LR.SetPosition(currentIndex + 1, new Vector3(Totems[0].transform.position.x, Totems[0].transform.position.y, -1f));
        }

        if (currentIndex == Totems.Length)
        {
            float Delta = 0;
            for (int i = 0; i < Totems.Length; i++)
            {
                Delta += Vector3.Distance(transform.position, Totems[i].transform.position);
            }
            Delta /= Totems.Length;
            CheckTotem();
            if (Vector3.Distance(Player.transform.position, transform.position) < Delta)
            {
                GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>().Damage(Damage);
            }
            Destroy(gameObject);
        }

    }

    void CheckTotem()
    {
        for (int i = 0; i < Totems.Length; i++)
        {
            try
            {
                if (Totems[i] == null || Totems[i].GetComponent<Enemy_Health>().ReturnCurrentHealth() <= 0)
                {
                    Destroy(gameObject);
                }

            }
            catch
            {

            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
       
            Effect();
       
       

    }
}
