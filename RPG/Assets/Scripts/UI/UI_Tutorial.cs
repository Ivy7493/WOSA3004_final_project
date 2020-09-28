using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Tutorial : MonoBehaviour
{
    [Header("Gameplay Based Text")]
    public string Spell_txt;
    public float Spell_time;

    [Header("Story Based Text")]
    public string Start_txt;
    public float Start_time;
    public string Mages_encounter_txt;
    public float Mage_encounter_time;
    public string Book_encounter_Txt;
    public float Book_encounter_time;
    public string first_enemy_encounter_txt;
    public float first_enemy_encounter_time;

    public string Movement_txt;
    public float movement_time;
    UI_Manager UIM;
    



    void Start()
    {
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        if(PlayerPrefs.GetFloat("MovementText",0f) == 0f)
        {
            UIM.SendNotification(Movement_txt, movement_time);
            PlayerPrefs.SetFloat("MovementText", 1f);
        }else if(PlayerPrefs.GetFloat("MovementText",0f) == 1f)
        {
           
        }
       
    }

   public void activate_start_txt()
    {
        if (PlayerPrefs.GetFloat("StartText", 0f) == 0f)
        {
            UIM.SendNotification(Start_txt, Start_time);
            PlayerPrefs.SetFloat("StartText", 1f);
        }
    }


  

    public void activate_book_txt()
    {

        UIM.SendNotification(Book_encounter_Txt, Book_encounter_time);
        
        
    }

    public void deactivate_book_txt()
    {
        
    }

    public void activate_mages_encounter()
    {
        if(PlayerPrefs.GetFloat("MageText",0f) == 0f)
        {
            UIM.SendNotification(Mages_encounter_txt, Mage_encounter_time);
            PlayerPrefs.SetFloat("MageText", 1f);

            
        }
      
    }
    public void deactivate_mages_encounter()
    {
        if(PlayerPrefs.GetFloat("MageText", 0f) == 0f)
        {
            
           
        }
       
    }

    public void activate_spell_items()
    {
        if(PlayerPrefs.GetFloat("SpellText",0f) == 0f)
        {
            UIM.SendNotification(Spell_txt, Spell_time);
            PlayerPrefs.SetFloat("SpellText", 1f);
        }
       
    }
    public void deactivate_spell_items()
    {
        
        
    }

    public void activate_first_enemy()
    {
        if (PlayerPrefs.GetFloat("FirstEnemy", 0f) == 0f)
        {
            UIM.SendNotification(first_enemy_encounter_txt, first_enemy_encounter_time);
            PlayerPrefs.SetFloat("FirstEnemy", 1f);
        }
    }

    public void deactivate_first_enemy()
    {
       
    }
   


    

}
