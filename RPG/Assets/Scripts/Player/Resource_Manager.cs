using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    float PlayerLevel;
    UI_Manager UIM;
    Game_Manager GM;

    void Start()
    {
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
       
        HPgen = HpScale * PlayerLevel;
        MPgen = MpScale * PlayerLevel;
        HealthScale();
        ManaScale();

    }

    public void RecalculateStatValues()
    {
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        HPgen = HpScale * PlayerLevel;
        MPgen = MpScale * PlayerLevel;
        HealthScale();
        ManaScale();
    }

    float HealthScale()
    {
        MaxHP = HpScale * PlayerLevel;
        return MaxHP;
    }

    float ManaScale()
    {
        MaxMP = MpScale * PlayerLevel;
        return MaxMP;
    }

    public void Damage(float _damage)
    {
        CurrentHP -= _damage;
        Debug.Log(CurrentHP);
        UIM.UpdateHealth(CurrentHP / MaxHP);
        if(CurrentHP <= 0)
        {
            //Put death code here, IDK what this does yet
            CurrentHP = MaxHP;
            GM.Death();
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

    private void Awake()
    {
        LoadPlayerResources();
    }

    void LoadPlayerResources()
    {
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        MaxHP = PlayerPrefs.GetFloat("MaxHP", HealthScale());
        MaxMP = PlayerPrefs.GetFloat("MaxMP", ManaScale());
        CurrentHP = PlayerPrefs.GetFloat("CurrentHP", MaxHP);
        CurrentMP = PlayerPrefs.GetFloat("CurrentMP", MaxMP);
        Debug.Log("Max HP: " + MaxHP + "Max MP: " + MaxMP);
        
    }

    private void OnApplicationQuit()
    {
        SaveResources();
    }

    void SaveResources()
    {
        PlayerPrefs.SetFloat("CurrentHP", CurrentHP);
        PlayerPrefs.SetFloat("CurrentMP", CurrentMP);
        PlayerPrefs.SetFloat("MaxHP", MaxHP);
        PlayerPrefs.SetFloat("MaxMP", MaxMP);
    }

    // Update is called once per frame
    void Update()
    {
        HPregen();
        MPregen();
    }
}
