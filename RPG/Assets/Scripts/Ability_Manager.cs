using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject AbilityFeet;
    GameObject AbilityHead;
    GameObject AbilityMain;
    GameObject AbilityOff;
    Spell_Manager SM;
    public float GCD;
    float counter = 0;
    bool CanCast = true;
    void Start()
    {
        
    }

    void GCDCounter()
    {
        if(CanCast == false)
        {
            counter += Time.deltaTime;
            if(counter >= GCD)
            {
                counter = 0;
                CanCast = true;
            }
        }
    }


    void UseMain()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && CanCast)
        {
            if(AbilityMain != null)
            {
                Instantiate(AbilityMain, transform.position, Quaternion.identity);
                CanCast = false;
            }
           
        }
    }

    void UseOff()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && CanCast)
        {
            if (AbilityOff != null)
            {
                Instantiate(AbilityOff, transform.position, Quaternion.identity);
                CanCast = false;
            }
           
        }
    }

    void UseFeet()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4) && CanCast)
        {
            if(AbilityFeet != null)
            {
                Instantiate(AbilityFeet, transform.position, Quaternion.identity);
                CanCast = false;
            }
           
        }
    }

    void UseHead()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && CanCast)
        {
            if(AbilityHead != null)
            {
                Instantiate(AbilityHead, transform.position, Quaternion.identity);
                CanCast = false;
            }
           
        }
    }

    private void Awake()
    {
        ///loading spellsetup
        LoadSpellState();
    }


    void LoadSpellState()
    {
        SM = GameObject.FindGameObjectWithTag("Spell_Manager").GetComponent<Spell_Manager>();
        float indexhead = PlayerPrefs.GetFloat("Head", 0);
        float indexMain = PlayerPrefs.GetFloat("Main", 0);
        float indexFeet = PlayerPrefs.GetFloat("Feet", 0);
        float indexOff = PlayerPrefs.GetFloat("Off", 0);
        AbilityFeet = SM.LookupFeet(indexFeet);
        AbilityHead = SM.LookupHead(indexhead);
        AbilityMain = SM.LookupMain(indexMain);
        AbilityOff = SM.LookupOff(indexOff);
    }

    private void OnApplicationQuit()
    {
        ///Saving current Spell setup
    }

    // Update is called once per frame
    void Update()
    {
        UseMain();
        UseHead();
        UseOff();
        UseFeet();
        GCDCounter();
    }
}
