using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interactions : MonoBehaviour
{
    public UI_Tutorial tut;
    [Header("Invoke timers")]
    public float movementTut;
    public float mage_encounter;
    public float spell_encounter;
    public float first_enemy_counter;


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
      
        if (collision.gameObject.tag == "Point1")
        {
            tut.activate_movement_txt();
            tut.Invoke("deactivate_movement_txt", movementTut);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Point2")
        {
            tut.activate_mages_encounter();
            tut.Invoke("deactivate_mages_encounter", mage_encounter);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Point3"))
        {
            tut.activate_spell_items();
            tut.Invoke("deactivate_spell_items", spell_encounter);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Point4"))
        {
            tut.activate_first_enemy();
            tut.Invoke("deactivate_first_enemy", first_enemy_counter);
        }
       
    }

   
}
