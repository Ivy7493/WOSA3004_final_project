using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ability_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject StaffLocation;
    GameObject AbilityFeet;
    GameObject AbilityHead;
    GameObject AbilityMain;
    GameObject AbilityOff;
    Spell_Manager SM;
    UI_Manager UIM;
    Resource_Manager RM;
    Experience_Manager EM;
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
        RM = GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>();
        EM = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>();
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

    void ManaCheck()
    {
        //Main Slot First
        try
        {
            float TempMana = AbilityMain.GetComponent<Mana_cost>().ReturnManaScale() * EM.ReturnLevel();
            if (RM.ReturnMana() < TempMana)
            {
                UIM.SetOnManaEffectUI("Main");
            }
            else if (RM.ReturnMana() >= TempMana)
            {
                UIM.SetOffManaEffectUI("Main");
            }
        }
        catch
        {
            Debug.Log("Ability Main Doesnt Use Mana!");
        }


        //Off Slot
        try
        {
            float TempMana = AbilityOff.GetComponent<Mana_cost>().ReturnManaScale() * EM.ReturnLevel();
            if (RM.ReturnMana() < TempMana)
            {
                UIM.SetOnManaEffectUI("Off");
            }
            else if (RM.ReturnMana() >= TempMana)
            {
                UIM.SetOffManaEffectUI("Off");
            }
        }
        catch
        {
            Debug.Log("Ability Off Doesnt Use Mana!");
        }

        //Head Slot
        try
        {
            float TempMana = AbilityHead.GetComponent<Mana_cost>().ReturnManaScale() * EM.ReturnLevel();
            if (RM.ReturnMana() < TempMana)
            {
                UIM.SetOnManaEffectUI("Head");
            }
            else if (RM.ReturnMana() >= TempMana)
            {
                UIM.SetOffManaEffectUI("Head");
            }
        }
        catch
        {
            Debug.Log("Ability Head Doesnt Use Mana!");
        }

    }

    /// <summary>
    /// These functions are called when a player casts one of their abilities
    /// </summary>


    void UseMain()
    {
        if (Input.GetMouseButtonDown(0) && CanCast && !IsMouseOverUI())
        {
            if(AbilityMain != null)
            {
                if(AbilityMain.GetComponent<Slot>().ReturnSpellLocation() == false)
                {
                    Instantiate(AbilityMain, Player.transform.position, Quaternion.identity);
                }else if(AbilityMain.GetComponent<Slot>().ReturnSpellLocation() == true)
                {
                    Instantiate(AbilityMain, StaffLocation.transform.position, Quaternion.identity);
                }
                CanCast = false;
            }
           
        }
    }

    void UseOff()
    {
        if (Input.GetKeyDown(KeyCode.Q) && CanCast && !IsMouseOverUI())
        {
            if (AbilityOff != null)
            {
                if(AbilityOff.GetComponent<Slot>().ReturnSpellLocation() == false)
                {
                    Instantiate(AbilityOff, Player.transform.position, Quaternion.identity);
                }else if(AbilityOff.GetComponent<Slot>().ReturnSpellLocation() == true)
                {
                    Instantiate(AbilityOff, StaffLocation.transform.position, Quaternion.identity);
                }
               
                CanCast = false;
            }
           
        }
    }

    void UseFeet()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CanBlink && !IsMouseOverUI())
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
        if (Input.GetMouseButtonDown(1) && CanCast && !IsMouseOverUI())
        {
            if(AbilityHead != null)
            {
                if(AbilityHead.GetComponent<Slot>().ReturnSpellLocation() == false)
                {
                    Instantiate(AbilityHead, Player.transform.position, Quaternion.identity);
                }else if(AbilityHead.GetComponent<Slot>().ReturnSpellLocation() == true)
                {
                    Instantiate(AbilityHead, StaffLocation.transform.position, Quaternion.identity);
                }
                
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

    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    
  

    private void OnApplicationQuit()
    {
        ///Saving current Spell setup
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<Player_motor>().ReturnStunStatus() == false)
        {
            UseMain();
            UseHead();
            UseOff();
            UseFeet();
        }
       
        ManaCheck();
        GCDCounter();
    }
}
