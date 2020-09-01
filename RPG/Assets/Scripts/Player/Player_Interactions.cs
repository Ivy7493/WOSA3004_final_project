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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point1"))
        {
            tut.activate_movement_txt();
            tut.Invoke("deactivate_movement_txt", movementTut);
        }

        if (other.gameObject.CompareTag("Point2"))
        {
            tut.activate_mages_encounter();
            tut.Invoke("deactivate_mages_encounter", mage_encounter);
        }

        if (other.gameObject.CompareTag("Point3"))
        {
            tut.activate_spell_items();
            tut.Invoke("deactivate_spell_items", spell_encounter);
        }
    }
}
