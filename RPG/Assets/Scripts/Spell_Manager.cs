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

    public int ReturnSpellIndex(GameObject _spell, string _slot)
    {
        switch (_slot)
        {
            case "Head":
                for(int i = 0; i < Head.Length; i++)
                {
                    if(_spell.name == Head[i].name)
                    {
                        return i;
                    }
                }
                break;
            case "Feet":
                for (int i = 0; i < Feet.Length; i++)
                {
                    if (_spell.name == Feet[i].name)
                    {
                        return i;
                    }
                }
                    break;
            case "Main":
                for (int i = 0; i < Main.Length; i++)
                {
                    if (_spell.name == Main[i].name)
                    {
                        return i;
                    }
                }
                    break;
            case "Off":
                for (int i = 0; i < Off.Length; i++)
                {
                    if (_spell.name == Off[i].name)
                    {
                        return i;
                    }
                }
                    break;
           
        }
        return 420;
    }

    void Update()
    {
        
    }
}
