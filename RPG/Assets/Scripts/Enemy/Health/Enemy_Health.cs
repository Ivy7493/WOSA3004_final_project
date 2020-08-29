using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float HealthScale;
    float Health;
    float MaxHealth;
    float PlayerLevel;
    public GameObject HUD;


    public bool HitEffect;
    bool EffectPlaying = false;
    SpriteRenderer Graphics;
    float FlashCounter = 0f;
    Color32 StartCol;
    LootTable LT;
    Stat_Manager STM;
    void Start()
    {
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        STM = GameObject.FindGameObjectWithTag("Stat_Manager").GetComponent<Stat_Manager>();
        Graphics = GetComponentInChildren<SpriteRenderer>();
        Health = PlayerLevel * HealthScale;
        MaxHealth = Health;
        if(HUD != null)
        {
            HUD.GetComponent<UI_Enemy_HUD>().UpdateHealthBar(1f);
        }
        StartCol = Graphics.color;
        try
        {
            LT = GetComponent<LootTable>();
        }
        catch
        {
            Debug.Log("LootTable was not found on enemy");
        }
    }



    //Makes the enemy flash red on hit
    void DamageEffect()
    {
        if(HitEffect == true && EffectPlaying == true)
        {
            FlashCounter += Time.deltaTime*10;
            Graphics.color = Color.Lerp(StartCol, Color.red, FlashCounter);
            if(FlashCounter >= 1)
            {
                FlashCounter = 0f;
                EffectPlaying = false;
                Graphics.color = StartCol;
            }
        }
    }

    public float ReturnMaxHealth()
    {
        return MaxHealth;
    }

    public float ReturnCurrentHealth()
    {
        return Health;
    }


    public void Damage(float _damage)
    {
        float TempDamage = STM.IsCrit(_damage);
        Health -= TempDamage;
        ///Will play the hit effect if not playing the hit effect
        if(EffectPlaying != true)
        {
            EffectPlaying = true;
        }
        ///////////////////////////////////////////////////////
        if(HUD != null)
        {
            float temp = Health / MaxHealth;
            HUD.GetComponent<UI_Enemy_HUD>().UpdateHealthBar(temp);
        }
        if(Health <= 0)
        {
            if(LT != null)
            {
                LT.DropLoot();
            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DamageEffect();
    }
}
