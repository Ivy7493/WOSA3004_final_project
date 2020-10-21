using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CastBar;
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
    public GameObject TalentNotification;
    public GameObject TalentNumber;
    public GameObject ZoneText;
    public GameObject ObjectInteractionTxt;
    public GameObject DamageText;
    public GameObject HPVal_txt;
    public GameObject ManaVal_txt;
    public GameObject ExpVal_txt;
    public GameObject StatsMenu;
    public GameObject CritStat_txt;
    public GameObject HealthStat_txt;
    public GameObject ManaStat_txt;
    public GameObject HPSStat_txt;
    public GameObject MPSStat_txt;
    public GameObject PushNotif;
    public GameObject DamageTextCrit;
    public GameObject DamageEffect;
    public GameObject HeadMana;
    public GameObject MainMana;
    public GameObject OffMana;
    public GameObject LevelUp;
    public GameObject TutorialMenuUI;
    public GameObject ControlsUI;
    public GameObject HudUI;
    public GameObject SpellsUI;
    public GameObject TalentsUI;
    
    Resource_Manager RM;
    Experience_Manager EM;
    Stat_Manager STM;
    GameObject Player;

    Queue<string> NotificationLog;
    Queue<float> NotificantionDuration;
    Stack<string> WindowStack;
    public static bool GameIsPaused = false;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        EM = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>();
        RM = GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>();
        STM = GameObject.FindGameObjectWithTag("Stat_Manager").GetComponent<Stat_Manager>();
        PauseScreenUI.SetActive(false);
        ItemPanel.SetActive(false);
        DeathEffect.SetActive(false);
        ZoneText.SetActive(false);
        CastBar.SetActive(false);
        SetHUDValues();
        NotificationLog = new Queue<string>();
        NotificantionDuration = new Queue<float>();
      
    }

    void SetStats()
    {
        HealthStat_txt.GetComponent<TextMeshProUGUI>().text = "MaxHealth: " + Mathf.RoundToInt((STM.ReturnMaxHealth() - 1)*100) + "%";
        ManaStat_txt.GetComponent<TextMeshProUGUI>().text = "MaxMana: " + Mathf.RoundToInt((STM.ReturnMaxMana() - 1)*100) + "%";
        CritStat_txt.GetComponent<TextMeshProUGUI>().text = "Crit: " + (int)((STM.ReturnSpellCrit() - 1)*100) + "%";
        HPSStat_txt.GetComponent<TextMeshProUGUI>().text = "HPS: " + Mathf.RoundToInt((STM.ReturnHP5() - 1)*100) + "%";
        MPSStat_txt.GetComponent<TextMeshProUGUI>().text = "MPS: " + Mathf.RoundToInt((STM.ReturnMP5() - 1)*100) + "%";
    }

    void SetHUDValues()
    {
        HPVal_txt.GetComponent<TextMeshProUGUI>().text = (int)RM.ReturnCurrentHP() + "/" + (int)RM.returnMaxHP(); ;
        ManaVal_txt.GetComponent<TextMeshProUGUI>().text = (int)RM.ReturnMana() + "/" + (int)RM.returnMaxMP(); ;
    }

    public void UpdateLevel(float _Level)
    {
        Level.GetComponent<Text>().text = _Level + "";
    }

    public void ActiveTalentPanel()
    {
        TalentPanel.SetActive(true);
        TalentNotification.SetActive(true);
    }

   public void SetCastBar(float _percent)
    {
        if(CastBar.activeInHierarchy == false)
        {
            CastBar.SetActive(true);
        }
        CastBar.GetComponent<Slider>().value = _percent;
        if(_percent >= 1)
        {
            CastBar.SetActive(false);
        }
    }

    public void SendNotification(string _note, float _duration)
    {
        NotificationLog.Enqueue(_note);
        NotificantionDuration.Enqueue(_duration);
    }


    //used to display control
    void NotificationDisplayControl()
    {
        if(NotificationLog.Count > 0 && PushNotif.activeInHierarchy == false)
        {
            PushNotif.SetActive(true);
            PushNotif.GetComponentInChildren<TextMeshProUGUI>().text = NotificationLog.Dequeue();
            float tempTime = NotificantionDuration.Dequeue();
            StartCoroutine(DisplayNotification(tempTime));
                
        }
    }

    IEnumerator DisplayNotification(float Time)
    {
        yield return new WaitForSeconds(Time);
        PushNotif.SetActive(false);
    }

    public void SetCastBarOff()
    {
        CastBar.GetComponent<Slider>().value = 0f;
        CastBar.SetActive(false);
    }

    

    public void DestroyTalentPanel()
    {
        TalentPanel.SetActive(false);
        TalentNotification.SetActive(false);
    }

    public void SetTalentNumber(float _number)
    {
        TalentNumber.GetComponent<TextMeshProUGUI>().text = "Talent points: " + _number;
    }

    public void UpdateExpBar(float _percent)
    {
     //   ExpBar.GetComponent<Slider>().value = _percent;
        ExpBar.GetComponent<Image>().fillAmount = _percent/100f;
        ExpVal_txt.GetComponent<TextMeshProUGUI>().text = (int)EM.ReturnCurrentEXP() + "/" + (int)EM.ReturnMaxEXPforLevel();
    }
    /// <summary>
    /// This section deals with ability infomation display on the UI
    /// </summary>
    /// <param name="_icon"></param>
    /// <param name="_name"></param>

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

    public void SetOnManaEffectUI(string _slot)
    {
        switch (_slot)
        {
            case "Main":
              if(MainMana.activeInHierarchy == false)
                {
                    MainMana.SetActive(true);
                }
                break;
            case "Off":
                if(OffMana.activeInHierarchy == false)
                {
                    OffMana.SetActive(true);
                }
                break;
            case "Head":
                if(HeadMana.activeInHierarchy == false)
                {
                    HeadMana.SetActive(true);
                }
                break;
        }
    }

    public void SetOffManaEffectUI(string _slot)
    {
        switch (_slot)
        {
            case "Main":
                if (MainMana.activeInHierarchy == true)
                {
                    MainMana.SetActive(false);
                }
                break;
            case "Off":
                if (OffMana.activeInHierarchy == true)
                {
                    OffMana.SetActive(false);
                }
                break;
            case "Head":
                if (HeadMana.activeInHierarchy == true)
                {
                    HeadMana.SetActive(false);
                }
                break;
        }
    }

    void StatUpdate()
    {
        if(StatsMenu.activeInHierarchy == true)
        {
            SetStats();
        }
    }

    public void ToggleStatMenu()
    {
        if(StatsMenu.activeInHierarchy == false)
        {
            StatsMenu.SetActive(true);
            SetStats();
        }else if(StatsMenu.activeInHierarchy == true)
        {
            StatsMenu.SetActive(false);
        }
       
    }

    public void SetLevelUp()
    {
        LevelUp.SetActive(true);
    }

    public void DamageEffectUI()
    {
        DamageEffect.SetActive(true);
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
       // ItemPanel.transform.position = new Vector3(Player.transform.position.x - 2, Player.transform.position.y, 0f);//Location;
        ItemDesc.GetComponent<TextMeshProUGUI>().text = _desc;
        ItemDesc.GetComponent<TextMeshProUGUI>().color = ItemColor;
        ItemName.GetComponent<TextMeshProUGUI>().text = _name;
        ItemName.GetComponent<TextMeshProUGUI>().color = ItemColor;
        ItemSlot.GetComponent<TextMeshProUGUI>().text = _slot;
        ItemSlot.GetComponent<TextMeshProUGUI>().color = ItemColor;
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

    public void SpawnDamageText(Vector3 location, float damage,bool crit)
    {
        if(crit == false)
        {
            GameObject temp = Instantiate(DamageText, location, Quaternion.identity);
            temp.GetComponent<TextMeshPro>().text = (int)damage + "";
        }else if(crit == true)
        {

            GameObject temp = Instantiate(DamageTextCrit, location, Quaternion.identity);
            temp.GetComponent<TextMeshPro>().text = (int)damage + "";
        }


    }

    public void SpawnStatusText(Vector3 location, string Effect)
    {
        GameObject temp = Instantiate(DamageText, location + new Vector3(0,1,0), Quaternion.identity);
        temp.GetComponent<TextMeshPro>().text = Effect;
    }


    public void UpdateHealth(float _health)
    {
      //  HealthBar.GetComponent<Slider>().value = _health;
        HealthBar.GetComponent<Image>().fillAmount = _health;
        HPVal_txt.GetComponent<TextMeshProUGUI>().text = (int)RM.ReturnCurrentHP() + "/" + (int)RM.returnMaxHP();


    }

    public void UpdateMana(float _Mana)
    {
        //ManaBar.GetComponent<Slider>().value = _Mana;
        ManaBar.GetComponent<Image>().fillAmount = _Mana;
        ManaVal_txt.GetComponent<TextMeshProUGUI>().text = (int)RM.ReturnMana() + "/" + +(int)RM.returnMaxMP();
    }

    public void CallDeathEffect()
    {
        DeathEffect.SetActive(true);
        GameObject.FindGameObjectWithTag("Sound_Manager").GetComponent<Sound_Manager>().PlayDeathSound();
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

    public void Tutorials()
    {
        PauseScreenUI.SetActive(false);
        TutorialMenuUI.SetActive(true);
    }

    public void Controls()
    {
        TutorialMenuUI.SetActive(false);
        ControlsUI.SetActive(true);
    }

    public void HUD()
    {
        TutorialMenuUI.SetActive(false);
        HudUI.SetActive(true);
    }

    public void Spells()
    {
        TutorialMenuUI.SetActive(false);
        SpellsUI.SetActive(true);
    }

    public void Talents()
    {
        TutorialMenuUI.SetActive(false);
        TalentsUI.SetActive(true);
    }

    public void Back()
    {
       if(HudUI.activeInHierarchy == true)
        {
            HudUI.SetActive(false);
            TutorialMenuUI.SetActive(true);
        }else if(ControlsUI.activeInHierarchy == true)
        {
            ControlsUI.SetActive(false);
            TutorialMenuUI.SetActive(true);
        }else if(TutorialMenuUI.activeInHierarchy == true)
        {
            TutorialMenuUI.SetActive(false);
            PauseScreenUI.SetActive(true);
        }else if(SpellsUI.activeInHierarchy == true)
        {
            SpellsUI.SetActive(false);
            TutorialMenuUI.SetActive(true);
        }else if(TalentsUI.activeInHierarchy == true)
        {
            TalentsUI.SetActive(false);
            TutorialMenuUI.SetActive(true);
        }
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
        NotificationDisplayControl();
        StatUpdate();
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
