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
    void Start()
    {
        
    }

    public void Damage(float _damage)
    {
        CurrentHP -= _damage;
        Debug.Log(CurrentHP);
        if(CurrentHP <= 0)
        {
            //Put death code here, IDK what this does yet
        }
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
