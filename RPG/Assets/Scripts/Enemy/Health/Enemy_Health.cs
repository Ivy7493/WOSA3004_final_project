using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float HealthScale;
    float Health;
    float MaxHealth;
    float PlayerLevel;
    public GameObject HUD;
    Material Death;


    public bool HitEffect;
    bool EffectPlaying = false;
    SpriteRenderer Graphics;
    float FlashCounter = 0f;
    Color32 StartCol;
    LootTable LT;
    Exp Experience;
    Stat_Manager STM;
    GameObject DeathEffect;
    Cursor_Manager CM;
    UI_Manager UIM;
    AIPath Motor;
    float DeathCounter = 0f;
    bool DeathOn = false;
    void Start()
    {
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        STM = GameObject.FindGameObjectWithTag("Stat_Manager").GetComponent<Stat_Manager>();
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        Graphics = GetComponentInChildren<SpriteRenderer>();
        Health = PlayerLevel * HealthScale;
        MaxHealth = Health;
        if(HUD != null)
        {
            HUD.GetComponent<UI_Enemy_HUD>().UpdateHealthBar(1f);
        }
        StartCol = Graphics.color;
        SystemQuery();
        DeathEffect = Resources.Load("Blood_Effect", typeof(GameObject)) as GameObject;
        CM = GameObject.FindGameObjectWithTag("Cursor_Manager").GetComponent<Cursor_Manager>();
        Death = Resources.Load("Disolve", typeof(Material)) as Material;
        Motor = GetComponent<AIPath>();
    }

    private void OnEnable()
    {
        RescaleHealth();
    }

    void RescaleHealth()
    {
        float CurrentPercent = Health / MaxHealth;
        PlayerLevel = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        MaxHealth = PlayerLevel * HealthScale;
        Health = CurrentPercent * MaxHealth;
        
    }

    void SystemQuery()
    {
        try
        {
            LT = GetComponent<LootTable>();
        }
        catch
        {
            Debug.Log("LootTable was not found on enemy");
        }

        try
        {
            Experience = GetComponent<Exp>();
        }
        catch
        {
            Debug.Log("Experience component not found on enemy");
        }
    }

    private void OnMouseOver()
    {
      //  CM.SwitchCursor("Enemy");
    }

    private void OnMouseExit()
    {
        CM.SwitchCursor("Default");
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

  
    void Disolve()
    {
        SpriteRenderer[] Renders = GetComponentsInChildren<SpriteRenderer>();
        for(int i = 0; i < Renders.Length; i++)
        {
            Renders[i].material = Death;
        }
        //StartCoroutine(DestoryAfterTime());
        DeathOn = true;
    }

    void DeathEffectFuc()
    {
        if(DeathOn == true)
        {
            if(Motor != null)
            {
                Motor.canMove = false;
            }
            DeathCounter += Time.deltaTime;
            SpriteRenderer[] Renders = GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < Renders.Length; i++)
            {
                Renders[i].material.SetFloat("_fade", 1 - DeathCounter);
            }
            if(DeathCounter >= 1f)
            {
                if (LT != null)
                {
                    LT.DropLoot();
                }
                if (Experience != null)
                {
                    Experience.AwardExp();
                }
                Destroy(gameObject);
            }
        }
       
    }

    IEnumerator DestoryAfterTime()
    {
        DeathCounter += Time.deltaTime;
        SpriteRenderer[] Renders = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < Renders.Length; i++)
        {
            Renders[i].material.SetFloat("_fade", 1 - DeathCounter);
        }
        yield return new WaitForSeconds(1f);
        if (LT != null)
        {
            LT.DropLoot();
        }
        if (Experience != null)
        {
            Experience.AwardExp();
        }
        Destroy(gameObject);
    }

    public float ReturnMaxHealth()
    {
        return MaxHealth;
    }

    public float ReturnCurrentHealth()
    {
        return Health;
    }

    public float ReturnCurrentHealthPercent()
    {
        return Health / MaxHealth;
    }


    public void Damage(float _damage)
    {
        float Diff = Random.Range(-1, 1f) * GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel()/2;
        float TempDamage = STM.IsCrit(_damage);
        TempDamage += Diff;
        Health -= TempDamage;
        EngagePlayer();
        UIM.SpawnDamageText(new Vector3(transform.position.x,transform.position.y + 2, 0f), TempDamage);
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
            /*
            if(LT != null)
            {
                LT.DropLoot();
            }
            if(Experience != null)
            {
                Experience.AwardExp();
            }
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            */
            Disolve();
           // Destroy(gameObject);
        }
    }

    //used to fix enemies doing nothing when being attacked from out of range
    void EngagePlayer()
    {
        try
        {
            AIDestinationSetter motor = GetComponent<AIDestinationSetter>();
            motor.target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        catch
        {
            Debug.Log("Pathfinding not found, this enemy can't move");
        }
    }

    // Update is called once per frame
    void Update()
    {
        DamageEffect();
        DeathEffectFuc();
    }
}
