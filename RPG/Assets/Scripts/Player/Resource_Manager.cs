using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public float DefaultHP;
    public float DefaultMP;
    float MaxHP;
    float MaxMP;
    float CurrentHP;
    float CurrentMP;
    public float HPgen;
    public float MPgen;
    UI_Manager UIM;

    void Start()
    {
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();    
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
            CurrentHP += HPgen * Time.deltaTime; ;
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
            CurrentMP += MPgen * Time.deltaTime; ;
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
        MaxHP = PlayerPrefs.GetFloat("MaxHP", DefaultHP);
        MaxMP = PlayerPrefs.GetFloat("MaxMP", DefaultMP);
        CurrentHP = PlayerPrefs.GetFloat("CurrentHP", MaxHP);
        CurrentMP = PlayerPrefs.GetFloat("CurrentMP", MaxMP);
        
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
