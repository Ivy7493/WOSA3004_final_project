using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public float CurrentLevel;
    public float MaxLevel;
    public float BaseLineExp;
    public float ExpPerLevelScale;
    float Expcount;
    float ExpForNextLevel;
    UI_Manager UIM;
    public GameObject LevelUpEffect;
    void Start()
    {
        ExpForNextLevel = BaseLineExp + (BaseLineExp * (ExpPerLevelScale / 100) * CurrentLevel);
        float temp = (Expcount / ExpForNextLevel) * 100f;
        UIM.UpdateExpBar(temp);
        UIM.UpdateLevel(CurrentLevel);
    }

    private void Awake()
    {
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        LoadExpData();
    }

    public float ReturnLevel()
    {
        return CurrentLevel;
    }

    public void AddExp(float _amount)
    {
        Expcount += _amount;
        if(Expcount >= ExpForNextLevel)
        {
            CurrentLevel++;
            Expcount = 0;
            ExpForNextLevel = BaseLineExp + (BaseLineExp * (ExpPerLevelScale / 100) * CurrentLevel);
            UIM.UpdateLevel(CurrentLevel);
            UIM.UpdateExpBar(0);
            Instantiate(LevelUpEffect, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>().RecalculateStatValues();
            GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>().ResetResources();

        }
        float temp = (Expcount / ExpForNextLevel) * 100f;
        UIM.UpdateExpBar(temp);
    }

    void LoadExpData()
    {
       
        CurrentLevel = PlayerPrefs.GetFloat("Level", 1);
        if(CurrentLevel > MaxLevel)
        {
            CurrentLevel = MaxLevel;
            PlayerPrefs.SetFloat("Level", CurrentLevel);
        }
        Expcount = PlayerPrefs.GetFloat("Expcount", 0);
    }

    private void OnDestroy()
    {
        SavePlayerData();
    }

    private void OnApplicationQuit()
    {
        SavePlayerData();
    }

    private void SavePlayerData()
    {
        PlayerPrefs.SetFloat("Level", CurrentLevel);
        PlayerPrefs.SetFloat("Expcount", Expcount);
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
