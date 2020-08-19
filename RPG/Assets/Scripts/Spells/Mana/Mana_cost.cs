using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana_cost : MonoBehaviour
{
    // Start is called before the first frame update
    public float ManaScale;
    float PlayerLevel;
    float Mana;
    Resource_Manager RM;
    private void Awake()
    {
        RM = GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>();
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        Mana = ManaScale * PlayerLevel;
       if(RM.ReturnMana() < Mana)
        {
            Destroy(gameObject);
        }
        else
        {
            RM.MinusMana(Mana);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
