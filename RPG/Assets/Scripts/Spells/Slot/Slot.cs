using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    // Start is called before the first frame update
    public string _slot;
    public bool _locationStaff = true;
    public string ReturnSlot()
    {
        return _slot;
    }

    public bool ReturnSpellLocation()
    {
        return _locationStaff;
    }
}
   
