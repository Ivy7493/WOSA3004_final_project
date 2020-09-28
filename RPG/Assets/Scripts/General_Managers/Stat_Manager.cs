using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    float SpellCrit;
    float MaxMana;
    float MaxHealth;
    float MP5;
    float HP5;
    float SpentPoints;
    public float ScaleRateCrit;
    public float ScaleRateMaxHealth;
    public float ScaleRateMaxMana;
    public float ScaleRateHealthRegen;
    public float ScaleRateManaRegen;
    public float CritMultiplyer;
    Experience_Manager EM;
    UI_Manager UIM;
    Resource_Manager RM;

    private void Awake()
    {
        LoadStatData();
    }

    void Start()
    {
        EM = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>();
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        RM = GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>();
        ScaleRateCrit = ScaleRateCrit / 100;
        ScaleRateMaxHealth = ScaleRateMaxHealth / 100;
        ScaleRateMaxMana = ScaleRateMaxMana / 100;
        ScaleRateHealthRegen = ScaleRateHealthRegen / 100;
        ScaleRateManaRegen = ScaleRateManaRegen / 100;
        CritMultiplyer = CritMultiplyer / 100;
        
    }


    public float ReturnSpellCrit()
    {
        return SpellCrit;
    }


    public void IncreaseSpellCrit()
    {
        SpellCrit += ScaleRateCrit;
        SpentPoints += 1f;
        PlayerPrefs.SetFloat("SpellCrit", SpellCrit);
        PlayerPrefs.SetFloat("SpentPoints", SpentPoints);
        Debug.Log("SpellCrit: " + SpellCrit);
        RM.RecalculateStatValues();
        
    }

    public void IncreaseMaxMana()
    {
        MaxMana += ScaleRateMaxMana;
        SpentPoints += 1f;
        PlayerPrefs.SetFloat("MaxMana", MaxMana);
        PlayerPrefs.SetFloat("SpentPoints", SpentPoints);
        Debug.Log("MaxMana: " + MaxMana);
        RM.RecalculateStatValues();
        Debug.Log(MaxMana + ": MaxMana");
    }

    public void IncreaseMaxHealth()
    {
        MaxHealth += ScaleRateMaxHealth;
        SpentPoints += 1f;
        PlayerPrefs.SetFloat("MaxHealth", MaxHealth);
        PlayerPrefs.SetFloat("SpentPoints", SpentPoints);
        Debug.Log("MaxHealth: " + MaxHealth);
        RM.RecalculateStatValues();
    }

    public void IncreaseMP5()
    {
        MP5 += ScaleRateManaRegen;
        SpentPoints += 1f;
        PlayerPrefs.SetFloat("MP5", MP5);
        PlayerPrefs.SetFloat("SpentPoints", SpentPoints);
        Debug.Log("MP5: " + MP5);
        RM.RecalculateStatValues();
    }

    public void IncreaseHP5()
    {
        HP5 += ScaleRateHealthRegen;
        SpentPoints += 1f;
        PlayerPrefs.SetFloat("HP5", HP5);
        PlayerPrefs.SetFloat("SpentPoints", SpentPoints);
        Debug.Log("HP5: " + HP5);
        RM.RecalculateStatValues();
    }

    public float ReturnMaxMana()
    {
        return MaxMana;
    }

    public float ReturnMaxHealth()
    {
        return MaxHealth;
    }

    public float ReturnMP5()
    {
        return MP5;
    }

    public float ReturnHP5()
    {
        return HP5;
    }

    void LoadStatData()
    {
        SpellCrit = PlayerPrefs.GetFloat("SpellCrit", 1f);
        MaxMana = PlayerPrefs.GetFloat("MaxMana", 1f);
        MaxHealth = PlayerPrefs.GetFloat("MaxHealth", 1f);
        MP5 = PlayerPrefs.GetFloat("MP5", 1f);
        HP5 = PlayerPrefs.GetFloat("HP5", 1f);
        SpentPoints = PlayerPrefs.GetFloat("SpentPoints", 1f);
    }

    public float IsCrit(float _damage)
    {
        float Temp = SpellCrit - 1;
        Temp *= 100f;
        float Select = Random.Range(0f, 101f);
        if(Select > Temp)
        {
            return _damage;
        }else if(Select < Temp)
        {
            Debug.Log("BIG CRITZ: " + _damage * CritMultiplyer);
            return _damage * CritMultiplyer;
        }
        return _damage;
    }

    void ActivateTalentPanel()
    {
        ///Activates the Talent Panel
        if(SpentPoints < EM.ReturnLevel())
        {
            UIM.ActiveTalentPanel();
            UIM.SetTalentNumber(EM.CurrentLevel - SpentPoints);
        }else if(SpentPoints >= EM.ReturnLevel())
        {
            UIM.DestroyTalentPanel();
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        ActivateTalentPanel();
    }
}
