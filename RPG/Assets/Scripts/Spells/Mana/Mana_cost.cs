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
    Sound_Manager SM;
    Effect_Manager EM;
    private void Awake()
    {
        RM = GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>();
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        Mana = ManaScale * PlayerLevel;
        EM = GameObject.FindGameObjectWithTag("Effect_Manager").GetComponent<Effect_Manager>();
       if(RM.ReturnMana() < Mana)
        {
            EM.NoManaEffect();
            Destroy(gameObject);
        }
        else
        {
            RM.MinusMana(Mana);
        }
    }

    public float ReturnManaScale()
    {
        return ManaScale;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
