using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    public string Name;
    float ItemIndex;
    public GameObject Spell;
    string Slot;
    public string Rarity;
    public string ItemDesc;
    public bool Permanent = false;
    Ability_Manager AM;
    GameObject Player;
    UI_Manager UIM;
    Spell_Manager SM;
    Cursor_Manager CM;
    SpriteRenderer SR;
    Staff_Manager STM;
    float DestoryRange = 30f;
    public float pickup_range=5f;
    
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        try
        {
            SM = GameObject.FindGameObjectWithTag("Spell_Manager").GetComponent<Spell_Manager>();
            AM = GameObject.FindGameObjectWithTag("Ability_Manager").GetComponent<Ability_Manager>();
            Player = GameObject.FindGameObjectWithTag("Player");
            UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
            CM = GameObject.FindGameObjectWithTag("Cursor_Manager").GetComponent<Cursor_Manager>();
            STM = GameObject.FindGameObjectWithTag("Player_Graphics").GetComponent<Staff_Manager>();
            Slot = Spell.GetComponent<Slot>().ReturnSlot();
            ItemIndex = SM.ReturnSpellIndex(Spell, Slot);
            InvokeRepeating("DestoryItem", 0, 5f);
          
            Debug.Log(Slot);
        }
        catch
        {
            Debug.Log("Caught loading error");
        }


        try
        {
            switch (Rarity)
            {
                case "Common":
                    SR.material.SetColor("_Rarity", Color.white);
                    break;
                case "Uncommon":
                    SR.material.SetColor("_Rarity", Color.green);
                    break;
                case "Rare":
                    SR.material.SetColor("_Rarity", Color.blue);
                    break;
                case "Epic":
                    SR.material.SetColor("_Rarity", Color.magenta);
                    break;
            }
        }
        catch
        {
 
        }
      
     
       
    }

    public string ReturnSlot()
    {
        return Slot;
    }

    public string ReturnRarity()
    {
        return Rarity;
    }


    void DestoryItem()
    {
        if(Permanent == false)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) > DestoryRange)
            {
                Destroy(gameObject);
            }
        }
       
    }



    private void OnMouseEnter()
    {
        if(UIM != null && Vector3.Distance(transform.position, Player.transform.position) <= pickup_range)
        {
            UIM.CallItemDisplay(Name, Slot, ItemDesc, new Vector3(transform.position.x, transform.position.y + 3.5f, 0f),Rarity);
        }
        CM.SwitchCursor("Item");
       
    }


    private void OnMouseExit()
    {
        UIM.DestoryItemDisplay();
        CM.SwitchCursor("Default");
    }

    private void OnDestroy()
    {
        if(UIM != null)
        {
            UIM.DestoryItemDisplay();
        }
        CM.SwitchCursor("Default");

    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(transform.position,Player.transform.position) <= pickup_range)
        {
            string tempType = "Default";
            switch (Rarity)
            {
                case "Common":
                    tempType = "Fire";
                    break;
                case "Uncommon":
                    tempType = "Arcane";
                    break;
                case "Rare":
                    tempType = "Frost";
                    break;
                case "Epic":
                    tempType = "Blood";
                    break;
            }
            switch (Slot)
            {
                case "Head":
                    AM.EquipHead(Spell);
                    PlayerPrefs.SetFloat("Head", ItemIndex);
                    STM.SetStaff(Slot, tempType);
                    break;
                case "Feet":
                    AM.EquipFeet(Spell);
                    PlayerPrefs.SetFloat("Feet", ItemIndex);
                    STM.SetStaff(Slot, tempType);
                    break;
                case "Main":
                    AM.EquipMain(Spell);
                    PlayerPrefs.SetFloat("Main", ItemIndex);
                    STM.SetStaff(Slot, tempType);
                    break;
                case "Off":
                    AM.EquipOff(Spell);
                    PlayerPrefs.SetFloat("Off", ItemIndex);
                    STM.SetStaff(Slot, tempType);
                    break;
            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DestoryItem();
    }
}
