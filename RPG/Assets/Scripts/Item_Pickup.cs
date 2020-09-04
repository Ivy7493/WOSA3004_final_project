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
    public string Slot;
    public string Rarity;
    public string ItemDesc;
    public bool Permanent = false;
    Ability_Manager AM;
    GameObject Player;
    UI_Manager UIM;
    Spell_Manager SM;
    float DestoryRange = 30f;
    public float pickup_range=5f;
    
    void Start()
    {
        try
        {
            SM = GameObject.FindGameObjectWithTag("Spell_Manager").GetComponent<Spell_Manager>();
            AM = GameObject.FindGameObjectWithTag("Ability_Manager").GetComponent<Ability_Manager>();
            Player = GameObject.FindGameObjectWithTag("Player");
            UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
            ItemIndex = SM.ReturnSpellIndex(Spell, Slot);
            InvokeRepeating("DestoryItem", 0, 5f);
        }
        catch
        {
            Debug.Log("Caught loading error");
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
        if(UIM != null)
        {
            UIM.CallItemDisplay(Name, Slot, ItemDesc, new Vector3(transform.position.x, transform.position.y + 2.5f, 0f),Rarity);
        }
       
    }


    private void OnMouseExit()
    {
        UIM.DestoryItemDisplay();
    }

    private void OnDestroy()
    {
        if(UIM != null)
        {
            UIM.DestoryItemDisplay();
        }
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && Vector3.Distance(transform.position,Player.transform.position) <= pickup_range)
        {
            switch (Slot)
            {
                case "Head":
                    AM.EquipHead(Spell);
                    PlayerPrefs.SetFloat("Head", ItemIndex);
                    break;
                case "Feet":
                    AM.EquipFeet(Spell);
                    PlayerPrefs.SetFloat("Feet", ItemIndex);
                    break;
                case "Main":
                    AM.EquipMain(Spell);
                    PlayerPrefs.SetFloat("Main", ItemIndex);
                    break;
                case "Off":
                    AM.EquipOff(Spell);
                    PlayerPrefs.SetFloat("Off", ItemIndex);
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
