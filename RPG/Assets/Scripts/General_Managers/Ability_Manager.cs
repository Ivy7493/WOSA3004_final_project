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
    UI_Manager UIM;
    GameObject Player;
    public float GCD;
    public float BlinkCD;
    float counter = 0;
    bool CanCast = true;
    bool CanBlink = true;
    float BlinkCounter;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    //THe globale GCD function stops players from being able to spam abilities through the setting of the CanCast bool after GCD amount of time
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
        if(CanBlink == false)
        {
            BlinkCounter += Time.deltaTime;
            if(BlinkCounter > BlinkCD)
            {
                BlinkCounter = 0;
                CanBlink = true;
            }

        }
    }

    /// <summary>
    /// These functions are called when a player casts one of their abilities
    /// </summary>


    void UseMain()
    {
        if (Input.GetMouseButtonDown(0) && CanCast)
        {
            if(AbilityMain != null)
            {
                Instantiate(AbilityMain, Player.transform.position, Quaternion.identity);
                CanCast = false;
            }
           
        }
    }

    void UseOff()
    {
        if (Input.GetMouseButtonDown(1) && CanCast)
        {
            if (AbilityOff != null)
            {
                Instantiate(AbilityOff, Player.transform.position, Quaternion.identity);
                CanCast = false;
            }
           
        }
    }

    void UseFeet()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CanBlink)
        {
            if(AbilityFeet != null)
            {
                Instantiate(AbilityFeet, Player.transform.position, Quaternion.identity);
                CanBlink = false;
            }
           
        }
    }

    void UseHead()
    {
        if (Input.GetMouseButtonDown(2) && CanCast)
        {
            if(AbilityHead != null)
            {
                Instantiate(AbilityHead, Player.transform.position, Quaternion.identity);
                CanCast = false;
            }
           
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// These functions are called when a player wants to equip new item
    /// </summary>


    public void EquipHead(GameObject _head)
    {
        AbilityHead = _head;
        string Name = AbilityHead.GetComponent<UI_Ability_info>().Name;
        Sprite Icon = AbilityHead.GetComponent<UI_Ability_info>().Icon;
        UIM.SetHeadIcon(Icon, Name);
    }

    public void EquipMain(GameObject _main)
    {
        AbilityMain = _main;
        string Name = AbilityMain.GetComponent<UI_Ability_info>().Name;
        Sprite Icon = AbilityMain.GetComponent<UI_Ability_info>().Icon;
        UIM.SetMainIcon(Icon, Name);
    }

    public void EquipFeet(GameObject _feet)
    {
        AbilityFeet = _feet;
        string Name = AbilityFeet.GetComponent<UI_Ability_info>().Name;
        Sprite Icon = AbilityFeet.GetComponent<UI_Ability_info>().Icon;
      //  UIM.SetFeetIcon(Icon, Name);
    }

    public void EquipOff(GameObject _off)
    {
        AbilityOff = _off;
        string Name = AbilityOff.GetComponent<UI_Ability_info>().Name;
        Sprite Icon = AbilityOff.GetComponent<UI_Ability_info>().Icon;
        UIM.SetOffIcon(Icon, Name);
    }

//-----------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// This function controls the loading of gear on game start up, it looks for the gears index in the spell manager and then gets the game object
    /// it returns the game object to the Equip function
    /// // the epquid function will then bind the item to the slot and update the UI as needed with Icon's and Names;
    /// </summary>

    
    void LoadSpellState()
    {
        SM = GameObject.FindGameObjectWithTag("Spell_Manager").GetComponent<Spell_Manager>();
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        float indexhead = PlayerPrefs.GetFloat("Head", 0);
        float indexMain = PlayerPrefs.GetFloat("Main", 0);
        float indexFeet = PlayerPrefs.GetFloat("Feet", 0);
        float indexOff = PlayerPrefs.GetFloat("Off", 0);
        EquipMain(SM.LookupMain(indexMain));
        EquipHead(SM.LookupHead(indexhead));
        EquipFeet(SM.LookupFeet(indexFeet));
        EquipOff(SM.LookupOff(indexOff));
    }


    //Loads game data assosiated with the ability manager on scene load
    private void Awake()
    {
        ///loading spellsetup
        LoadSpellState();
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
