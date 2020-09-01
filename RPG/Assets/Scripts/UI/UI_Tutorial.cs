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
    //public GameObject Book_encounter;

    



    void Start()
    {
        Invoke("deactivate_start_txt", 8F);
    }

   
    public void deactivate_start_txt()
    {
        Destroy(Start_txt);
    }

    public void activate_movement_txt()
    {
        Start_txt.SetActive(true);

    }
    public void deactivate_movement_txt()
    {
        Destroy(Movement_txt);
    }



    public void activate_mages_encounter()
    {
        Mages_encounter.SetActive(true);
    }
    public void deactivate_mages_encounter()
    {
        Destroy(Mages_encounter);
    }

    public void activate_spell_items()
    {
        Spell_txt.SetActive(true);
    }
    public void deactivate_spell_items()
    {
        Destroy(Spell_txt);
    }

   


    

}
