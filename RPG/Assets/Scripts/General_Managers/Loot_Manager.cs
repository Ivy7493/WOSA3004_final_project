using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Items;


    GameObject[] Epics = new GameObject[0];
    GameObject[] Rares = new GameObject[0];
    GameObject[] Uncommons = new GameObject[0];
    GameObject[] Commons = new GameObject[0];

    

    public float CommonThreshold;
    public float UncommonThreshold;
    public float RareThreshold;
    public float EpicThrehold;

    private void Awake()
    {
        Setup();
        
        Debug.Log("Epics!");
        for(int i = 0; i < Epics.Length; i ++)
        {
            Debug.Log(Epics[i].name);
        }
        Debug.Log("Rares!");
        for (int i = 0; i < Rares.Length; i++)
        {
            Debug.Log(Rares[i].name);
        }
        Debug.Log("Uncommons!");
        for (int i = 0; i < Uncommons.Length; i++)
        {
          
            Debug.Log(Uncommons[i].name);
        }
        Debug.Log("Commons!");
        for (int i = 0; i < Commons.Length; i++)
        {
            Debug.Log(Commons[i].name);
        }
       
    }
    void Start()
    {
        
    }

    void Setup()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            string Sort = Items[i].GetComponent<Item_Pickup>().ReturnRarity();
            switch (Sort)
            {
                case "Epic":
                    AddItem(Items[i], "Epic");
                    Debug.Log(Items[i].name + " was added to Epics!");
                    break;
                case "Rare":
                    AddItem(Items[i], "Rare");
                    Debug.Log(Items[i].name + " was added to Rares!");
                    break;
                case "Uncommon":
                    AddItem(Items[i], "Uncommon");
                    Debug.Log(Items[i].name + " was added to Uncommons!");
                    break;
                case "Common":
                    AddItem(Items[i], "Common");
                    Debug.Log(Items[i].name + " was added to Commons!");
                    break;
            }
        }
    }

    void AddItem(GameObject _item, string _Rarity)
    {
        float Resize = 0f;
        switch (_Rarity)
        {
            case "Epic":
                Resize = Epics.Length;
                break;
            case "Rare":
                Resize = Rares.Length;
                break;
            case "Uncommon":
                Resize = Uncommons.Length;
                break;
            case "Common":
                Resize = Commons.Length;
                break;
        }
        GameObject[] NewArray = new GameObject[(int)Resize + 1];
        for(int i = 0; i < Resize; i++)
        {
            switch (_Rarity)
            {
                case "Epic":
                    try
                    {
                        NewArray[i] = Epics[i];
                    }
                    catch
                    {
                        Debug.Log("Probs first time set up");
                    }
                    break;
                case "Rare":
                    try
                    {
                        NewArray[i] = Rares[i];
                    }
                    catch
                    {
                        Debug.Log("Probs first time set up");
                    }
                    break;
                case "Uncommon":
                    try
                    {
                        NewArray[i] = Uncommons[i];
                    }
                    catch
                    {
                        Debug.Log("Probs first time set up");
                    }
                    break;
                case "Common":
                    try
                    {
                        NewArray[i] = Commons[i];
                    }
                    catch
                    {
                        Debug.Log("Probs first time set up");
                    }
                    break;

            }
           
           
        }
        NewArray[(int)Resize] = _item;
        switch (_Rarity)
        {
            case "Epic":
                Epics = NewArray;
                break;
            case "Rare":
                Rares = NewArray;
                break;
            case "Uncommon":
                Uncommons = NewArray;
                break;
            case "Common":
                Commons = NewArray;
                break;
        }

    }

  



   

   

    public GameObject ReturnLoot(float _magic)
    {
        float RandomChance = Random.Range(0, 101);
        RandomChance = RandomChance/2 + _magic/2;
        Debug.Log("Magic find value: " + RandomChance);
       
        if (RandomChance >= EpicThrehold)
        {
            Debug.Log("Epic!: " + RandomChance + ", " + EpicThrehold);
            float select = Random.Range(0, Epics.Length);
            return Epics[(int)select];
        }
        else if (RandomChance >= RareThreshold)
        {
            Debug.Log("Rare!: " + RandomChance + ", " + RareThreshold);
            float select = Random.Range(0, Rares.Length);
            return Rares[(int)select];
        }
        else if (RandomChance >= UncommonThreshold)
        {
            Debug.Log("Uncommon!: " + RandomChance + ", " + UncommonThreshold);
            float select = Random.Range(0, Uncommons.Length);
            return Uncommons[(int)select];
        }
        else if (RandomChance >= CommonThreshold)
        {
            Debug.Log("Common!: " + RandomChance + ", " + CommonThreshold);
            float select = Random.Range(0, Commons.Length);
            return Commons[(int)select];
        }
        else
        {
            return null;
        }


    }
        
      
    }

    // Update is called once per frame
  