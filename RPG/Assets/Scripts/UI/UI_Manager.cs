using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AbilityMain;
    public GameObject AbilityFeet;
    public GameObject AbilityOff;
    public GameObject AbilityHead;
    public GameObject ExpBar;
    public GameObject Level;
    public GameObject ItemPanel;
    public GameObject ItemName;
    public GameObject ItemSlot;
    public GameObject ItemDesc;
  
    void Start()
    {
        ItemPanel.SetActive(false);
    }

    public void UpdateLevel(float _Level)
    {
        Level.GetComponent<Text>().text = _Level + "";
    }

    public void UpdateExpBar(float _percent)
    {
        ExpBar.GetComponent<Slider>().value = _percent;
    }


    public void SetHeadIcon(Sprite _icon, string _name)
    {
        AbilityHead.GetComponent<Image>().sprite = _icon;
    }

    public void SetMainIcon(Sprite _icon, string _name)
    {
        AbilityMain.GetComponent<Image>().sprite = _icon;
    }

    public void SetFeetIcon(Sprite _icon, string _name)
    {
        AbilityFeet.GetComponent<Image>().sprite = _icon;
    }

    public void SetOffIcon(Sprite _icon, string _name)
    {
        AbilityOff.GetComponent<Image>().sprite = _icon;
    }

    public void CallItemDisplay(string _name, string _slot, string _desc, Vector3 Location)
    {
        ItemPanel.SetActive(true);
        ItemPanel.transform.position = Location;
        ItemDesc.GetComponent<Text>().text = _desc;
        ItemName.GetComponent<Text>().text = _name;
        ItemSlot.GetComponent<Text>().text = _slot;
    } 

    public void DestoryItemDisplay()
    {
        if(ItemPanel != null)
        {
            ItemPanel.SetActive(false);
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
