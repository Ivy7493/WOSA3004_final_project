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
    Experience_Manager EM;
    

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
        EM = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>();
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
        Debug.Log("DropChance: " + _magic + " RandomChance: " + RandomChance);
        if(RandomChance <= _magic)
        {
            float LevelChance = EM.ReturnLevel() / EM.ReturnMaxLevel() * 100;
            RandomChance = Random.Range(0, 101);
            Debug.Log("Magic find value: " + RandomChance);

            if (RandomChance >= (EpicThrehold - EM.ReturnLevel()))
            {
                Debug.Log("Epic!: " + RandomChance + ", " + (EpicThrehold - EM.ReturnLevel()));
                float select = Random.Range(0, Epics.Length);
                return Epics[(int)select];
            }
            else if (RandomChance >= (RareThreshold - EM.ReturnLevel()))
            {
                Debug.Log("Rare!: " + RandomChance + ", " + (RareThreshold - EM.ReturnLevel()));
                float select = Random.Range(0, Rares.Length);
                return Rares[(int)select];
            }
            else if (RandomChance >= (UncommonThreshold - EM.ReturnLevel()))
            {
                Debug.Log("Uncommon!: " + RandomChance + ", " + (UncommonThreshold - EM.ReturnLevel()));
                float select = Random.Range(0, Uncommons.Length);
                return Uncommons[(int)select];
            }
            else if (RandomChance >= CommonThreshold - EM.ReturnLevel())
            {
                Debug.Log("Common!: " + RandomChance + ", " + (CommonThreshold - EM.ReturnLevel()));
                float select = Random.Range(0, Commons.Length);
                return Commons[(int)select];
            }
            else
            {
                return null;
            }
        }
        return null;
      


    }
        
      
    }

    // Update is called once per frame
  