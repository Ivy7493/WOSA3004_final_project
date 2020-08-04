using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Head;
    public GameObject[] Main;
    public GameObject[] Off;
    public GameObject[] Feet;
    void Start()
    {
        
    }

    // Update is called once per frame

    public GameObject LookupHead(float _index)
    {

        return Head[(int)_index];
    }

    public GameObject LookupMain(float _index)
    {
        return Main[(int)_index];
    }

    public GameObject LookupOff(float _index)
    {
        return Off[(int)_index];
    }

    public GameObject LookupFeet(float _index)
    {
        return Feet[(int)_index];
    }

    void Update()
    {
        
    }
}
