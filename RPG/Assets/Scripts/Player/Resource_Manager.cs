using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resource_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    float MaxHP;
    float MaxMP;
    float CurrentHP;
    float CurrentMP;
    float HPgen;
    float MPgen;
    public float MpScale;
    public float HpScale;
    public float MP_GenScale;
    public float HP_GenScale;
    float PlayerLevel;
    UI_Manager UIM;
    Game_Manager GM;
    Stat_Manager STM;
    Music_Manager MM;
    Effect_Manager EFM;
    

    void Awake()
    {

        LoadPlayerResources();
    }

    void Start()
    {
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
        STM = GameObject.FindGameObjectWithTag("Stat_Manager").GetComponent<Stat_Manager>();
        MM = GameObject.FindGameObjectWithTag("Music_Manager").GetComponent<Music_Manager>();
        EFM = GameObject.FindGameObjectWithTag("Effect_Manager").GetComponent<Effect_Manager>();
        UIM.UpdateHealth(CurrentHP);
        UIM.UpdateMana(CurrentMP);
        RecalculateStatValues();

    }

    public void ResetResources()
    {
        CurrentHP = MaxHP;
        CurrentMP = MaxMP;
        
    }

    public void RecalculateStatValues()
    {
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        HPgenScale();
        MPgenScale();
        HealthScale();
        ManaScale();
        Debug.Log("MaxMP: " + MaxMP);
    }

    float HealthScale()
    {
        MaxHP = HpScale * PlayerLevel * STM.ReturnMaxHealth();
        return MaxHP;
    }

    void MPgenScale()
    {
        MPgen = MP_GenScale * PlayerLevel * STM.ReturnMP5();
    }

    void HPgenScale()
    {
        HPgen = HP_GenScale * PlayerLevel * STM.ReturnHP5();
    } 

    float ManaScale()
    {
        Debug.Log("STM Value: " + STM.ReturnMaxMana());
        MaxMP = MpScale * PlayerLevel * STM.ReturnMaxMana();
        return MaxMP;
    }

    public void Damage(float _damage)
    {
        CurrentHP -= _damage;
        Debug.Log(CurrentHP);
        UIM.UpdateHealth(CurrentHP / MaxHP);
        EFM.ScreenShake(0.1f);
        if (CurrentHP <= 0)
        {
            //Put death code here, IDK what this does yet
            CurrentHP = MaxHP;
            UIM.UpdateHealth(CurrentHP / MaxHP);
            GM.Death();
            MM.PlayStartingArea();
            
        }
    }

    public void MinusMana(float _mana)
    {
        CurrentMP -= _mana;
        UIM.UpdateMana(CurrentMP/MaxMP);
    }

    public float ReturnMana()
    {
        return CurrentMP;
    }

    public float ReturnHealth()
    {
        return CurrentHP;
    }

    void HPregen()
    {
        if(CurrentHP < MaxHP)
        {
            CurrentHP += HPgen * Time.deltaTime/10;
            if(CurrentHP > MaxHP)
            {
                CurrentHP = MaxHP;
            }
            UIM.UpdateHealth(CurrentHP / MaxHP);
        }

       
    }

    void MPregen()
    {
        if(CurrentMP < MaxMP)
        {
            CurrentMP += MPgen * Time.deltaTime/5; ;
            if(CurrentMP > MaxMP)
            {
                CurrentMP = MaxMP;
            }
            UIM.UpdateMana(CurrentMP / MaxMP);
        }

    }

    

    void LoadPlayerResources()
    {
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        STM = GameObject.FindGameObjectWithTag("Stat_Manager").GetComponent<Stat_Manager>();
        MaxHP = HealthScale();
        MaxMP = ManaScale();
        CurrentHP = PlayerPrefs.GetFloat("CurrentHP", MaxHP);
        CurrentMP = PlayerPrefs.GetFloat("CurrentMP", MaxMP);
        
    }

    private void OnDestroy()
    {
        SaveResources();
    }

    private void OnApplicationQuit()
    {
        SaveResources();
    }

    void SaveResources()
    {
        PlayerPrefs.SetFloat("CurrentHP", CurrentHP);
        PlayerPrefs.SetFloat("CurrentMP", CurrentMP);
    }

    // Update is called once per frame
    void Update()
    {
        HPregen();
        MPregen();
    }
}
