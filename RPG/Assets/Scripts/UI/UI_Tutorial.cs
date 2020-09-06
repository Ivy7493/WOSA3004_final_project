using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Tutorial : MonoBehaviour
{
    [Header("Gameplay Based Text")]
    public GameObject Movement_txt;
    public GameObject Spell_txt;

    [Header("Story Based Text")]
    public GameObject Start_txt;
    public GameObject Mages_encounter;
    public GameObject Book_encounter;
    public GameObject first_enemy_encounter;

    



    void Start()
    {
        if(PlayerPrefs.GetFloat("StartText",0f) == 0f)
        {
            Invoke("deactivate_start_txt", 5f);
            PlayerPrefs.SetFloat("StartText", 1f);
        }else if(PlayerPrefs.GetFloat("StartText",0f) == 1f)
        {
            deactivate_start_txt();
        }
       
    }

   
    public void deactivate_start_txt()
    {
        Destroy(Start_txt);
    }

    public void activate_movement_txt()
    {
       if(PlayerPrefs.GetFloat("MovementText",0f) == 0f)
        {
            Movement_txt.SetActive(true);
        }
      

    }
    public void deactivate_movement_txt()
    {
        if(PlayerPrefs.GetFloat("MovementText", 0f) == 0f)
        {
            Destroy(Movement_txt);
            PlayerPrefs.SetFloat("MovementText", 1f);
            
           
        }
       
    }

    public void activate_book_txt()
    {
        
            Book_encounter.SetActive(true);
        
        
    }

    public void deactivate_book_txt()
    {
        Book_encounter.SetActive(false);
    }

    public void activate_mages_encounter()
    {
        if(PlayerPrefs.GetFloat("MageText",0f) == 0f)
        {
            Mages_encounter.SetActive(true);
            
        }
      
    }
    public void deactivate_mages_encounter()
    {
        if(PlayerPrefs.GetFloat("MageText", 0f) == 0f)
        {
            Destroy(Mages_encounter);
            PlayerPrefs.SetFloat("MageText", 1f);
        }
       
    }

    public void activate_spell_items()
    {
        if(PlayerPrefs.GetFloat("SpellText",0f) == 0f)
        {
            Spell_txt.SetActive(true);
        }
       
    }
    public void deactivate_spell_items()
    {
        if(PlayerPrefs.GetFloat("SpellText", 0f) == 0f)
        {
            Destroy(Spell_txt);
            PlayerPrefs.SetFloat("SpellText", 1f);
        }
        
    }

    public void activate_first_enemy()
    {
        if (PlayerPrefs.GetFloat("FirstEnemy", 0f) == 0f)
        {
            first_enemy_encounter.SetActive(true);
        }
    }

    public void deactivate_first_enemy()
    {
        if (PlayerPrefs.GetFloat("FirstEnemy", 0f) == 0f)
        {
            Destroy(first_enemy_encounter);
            PlayerPrefs.SetFloat("FirstEnemy", 1f);
        }
    }
   


    

}
