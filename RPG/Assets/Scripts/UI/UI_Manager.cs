using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    public GameObject HealthBar;
    public GameObject ManaBar;
    public GameObject DeathEffect;
    public GameObject PauseScreenUI;
    public GameObject TalentPanel;
    public GameObject TalentNumber;
    public GameObject ZoneText;
    public GameObject ObjectInteractionTxt;
    public GameObject DamageText;
    public GameObject HPVal_txt;
    public GameObject ManaVal_txt;
    public GameObject ExpVal_txt;
    public GameObject StatsMenu;
    public static bool GameIsPaused = false;
    void Start()
    {
        PauseScreenUI.SetActive(false);
        ItemPanel.SetActive(false);
        DeathEffect.SetActive(false);
        ZoneText.SetActive(false);
    }

    public void UpdateLevel(float _Level)
    {
        Level.GetComponent<Text>().text = _Level + "";
    }

    public void ActiveTalentPanel()
    {
        TalentPanel.SetActive(true);
    }

    public void DestroyTalentPanel()
    {
        TalentPanel.SetActive(false);
    }

    public void SetTalentNumber(float _number)
    {
        TalentNumber.GetComponent<Text>().text = "Talent points: " + _number;
    }

    public void UpdateExpBar(float _percent)
    {
        ExpBar.GetComponent<Slider>().value = _percent;
    }


    public void SetHeadIcon(Sprite _icon, string _name)
    {
        AbilityHead.GetComponent<Image>().sprite = _icon;
        GameObject.FindGameObjectWithTag("UI_HeadName").GetComponent<Text>().text = _name;
    }

    public void SetMainIcon(Sprite _icon, string _name)
    {
        AbilityMain.GetComponent<Image>().sprite = _icon;
        GameObject.FindGameObjectWithTag("UI_MainName").GetComponent<Text>().text = _name;
    }

    public void SetFeetIcon(Sprite _icon, string _name)
    {
        AbilityFeet.GetComponent<Image>().sprite = _icon;
        GameObject.FindGameObjectWithTag("UI_FeetName").GetComponent<Text>().text = _name;
    }

    public void SetOffIcon(Sprite _icon, string _name)
    {
        AbilityOff.GetComponent<Image>().sprite = _icon;
        GameObject.FindGameObjectWithTag("UI_OffName").GetComponent<Text>().text = _name;
    }

    public void TurnOnStatsMenu()
    {
        StatsMenu.SetActive(true);
    }

    public void TurnOffStatsMenu()
    {
        StatsMenu.SetActive(false);
    }
    public void CallItemDisplay(string _name, string _slot, string _desc, Vector3 Location, string Rarity)
    {
        Color ItemColor = Color.white;
        switch (Rarity)
        {
            case "Epic":
                ItemColor = Color.magenta;
                break;
            case "Rare":
                ItemColor = Color.blue;
                break;
            case "Uncommon":
                ItemColor = Color.green;
                break;
            case "Common":
                ItemColor = Color.white;
                break;
        }
        ObjectInteractionTxt.SetActive(true);
        ItemPanel.SetActive(true);
        ItemPanel.transform.position = Location;
        ItemDesc.GetComponent<Text>().text = _desc;
        ItemDesc.GetComponent<Text>().color = ItemColor;
        ItemName.GetComponent<Text>().text = _name;
        ItemName.GetComponent<Text>().color = ItemColor;
        ItemSlot.GetComponent<Text>().text = _slot;
        ItemSlot.GetComponent<Text>().color = ItemColor;
        ObjectInteractionTxt.transform.position = new Vector3(Location.x, Location.y - 5f, 0f);
    } 

    public void CallInteractionDisplay(Vector3 Location)
    {
        if(ObjectInteractionTxt.activeInHierarchy == false)
        {
            ObjectInteractionTxt.SetActive(true);
        }
        ObjectInteractionTxt.transform.position = Location;
    }

    public void DestroyInteractionDisplay()
    {
        if(ObjectInteractionTxt.activeInHierarchy == true)
        {
            ObjectInteractionTxt.SetActive(false);
        }
    }

    public void SpawnDamageText(Vector3 location, float damage)
    {
        GameObject temp = Instantiate(DamageText, location, Quaternion.identity);
        temp.GetComponent<TextMeshPro>().text = (int)damage + "";
    }


    public void UpdateHealth(float _health)
    {
        HealthBar.GetComponent<Slider>().value = _health;


    }

    public void UpdateMana(float _Mana)
    {
        ManaBar.GetComponent<Slider>().value = _Mana;
    }

    public void CallDeathEffect()
    {
        DeathEffect.SetActive(true);
    }

    public void DestoryItemDisplay()
    {
        if(ItemPanel != null)
        {
            ItemPanel.SetActive(false);
            ObjectInteractionTxt.SetActive(false);
        }
        
    }

    public void DisplayZone(string _Zone)
    {
        ZoneText.SetActive(true);
        ZoneText.GetComponentInChildren<Text>().text = _Zone;
    }


    public void SetExptxt(float exp)
    {
        ExpVal_txt.GetComponent<TextMeshPro>().text = exp.ToString();
    }
   
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseScreenUI.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseScreenUI.SetActive(true);
    }

    public void NewGame()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
