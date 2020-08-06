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
    public string ItemDesc;
    Ability_Manager AM;
    GameObject Player;
    UI_Manager UIM;
    Spell_Manager SM;
    void Start()
    {
        SM = GameObject.FindGameObjectWithTag("Spell_Manager").GetComponent<Spell_Manager>();
        AM = GameObject.FindGameObjectWithTag("Ability_Manager").GetComponent<Ability_Manager>();
        Player = GameObject.FindGameObjectWithTag("Player");
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        ItemIndex = SM.ReturnSpellIndex(Spell, Slot);
       
    }


    private void OnMouseEnter()
    {
        UIM.CallItemDisplay(Name, Slot, ItemDesc, new Vector3(transform.position.x ,transform.position.y + 2.5f,0f));
    }


    private void OnMouseExit()
    {
        UIM.DestoryItemDisplay();
    }

    private void OnDestroy()
    {
        UIM.DestoryItemDisplay();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && Vector3.Distance(transform.position,Player.transform.position) <= 2 )
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
                    PlayerPrefs.SetFloat("Head", ItemIndex);
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
        
    }
}
