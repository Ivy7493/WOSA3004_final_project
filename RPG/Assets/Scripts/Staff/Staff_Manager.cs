using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Head;
    public GameObject Main;
    public GameObject Off;
    public GameObject Lamb;

    string CurrentHead;
    string CurrentMain;
    string CurrentOff;

    public Color32 FireColor;
    public Color32 ArcaneColor;
    public Color32 FrostColor;
    public Color32 BloodColor;
    public Color32 DefaultColor;

    void Start()
    {
        SetStaff("Head", CurrentHead);
        SetStaff("Main", CurrentMain);
        SetStaff("Off", CurrentOff);
       
    }


    void CheckLamb()
    {
        if (CurrentHead == CurrentMain && CurrentHead == CurrentOff)
        {
           
            switch (CurrentHead)
            {
                case "Fire":
                    Lamb.GetComponent<SpriteRenderer>().color = FireColor;
                    break;
                case "Arcane":
                    Lamb.GetComponent<SpriteRenderer>().color = ArcaneColor;
                    break;
                case "Frost":
                    Lamb.GetComponent<SpriteRenderer>().color = FrostColor;
                    break;
                case "Blood":
                    Lamb.GetComponent<SpriteRenderer>().color = BloodColor;
                    break;
            }
        }
        else
        {
            Lamb.GetComponent<SpriteRenderer>().color = DefaultColor;
        }
    }

    public void SetStaff(string _Slot,string _Type)
    {
        Color32 TempColor = DefaultColor;
        switch (_Type)
        {
            case "Fire":
                TempColor = FireColor;
                break;
            case "Arcane":
                TempColor = ArcaneColor;
                break;
            case "Frost":
                TempColor = FrostColor;
                break;
            case "Blood":
                TempColor = BloodColor;
                break;
        }
        switch (_Slot)
        {
            case "Head":
                CurrentHead = _Type;
                Head.GetComponent<SpriteRenderer>().color = TempColor;
                PlayerPrefs.SetString("CurrentHead", _Type);
                break;
            case "Main":
                CurrentMain = _Type;
                Main.GetComponent<SpriteRenderer>().color = TempColor;
                PlayerPrefs.SetString("CurrentMain", _Type);
                break;
            case "Off":
                CurrentOff = _Type;
                Off.GetComponent<SpriteRenderer>().color = TempColor;
                PlayerPrefs.SetString("CurrentOff", _Type);
                break;
        }

       

    }


    private void Awake()
    {
        CurrentHead = PlayerPrefs.GetString("CurrentHead", "Default");
        CurrentMain = PlayerPrefs.GetString("CurrentMain", "Default");
        CurrentOff = PlayerPrefs.GetString("CurrentOff", "Default");
    }

    // Update is called once per frame
    void Update()
    {
        CheckLamb();
    }
}
