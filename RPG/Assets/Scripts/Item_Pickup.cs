using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    public string Name;
    public float ItemIndex;
    public GameObject Spell;
    public string Slot;
    public string ItemDesc;
    public GameObject UIpanel;
    public GameObject UIname;
    public GameObject UIDesc;
    public GameObject UISlot;
    Ability_Manager AM;
    GameObject Player;
    void Start()
    {
        AM = GameObject.FindGameObjectWithTag("Ability_Manager").GetComponent<Ability_Manager>();
        Player = GameObject.FindGameObjectWithTag("Player");
        UIname.GetComponent<Text>().text = Name;
        UIDesc.GetComponent<Text>().text = ItemDesc;
        UISlot.GetComponent<Text>().text = Slot;
        UIpanel.SetActive(false);
    }


    private void OnMouseEnter()
    {
        UIpanel.SetActive(true);
    }


    private void OnMouseExit()
    {
        UIpanel.SetActive(false);
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
