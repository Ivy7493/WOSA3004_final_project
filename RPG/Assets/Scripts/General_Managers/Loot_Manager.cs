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
        Debug.Log(Epics);
        Debug.Log(Rares);
        Debug.Log(Uncommons);
        Debug.Log(Commons);
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
                    break;
                case "Rare":
                    AddItem(Items[i], "Rare");
                    break;
                case "Uncommon":
                    AddItem(Items[i], "Uncommon");
                    break;
                case "Common":
                    AddItem(Items[i], "Common");
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
            try
            {
                NewArray[i] = Epics[i];
            }
            catch
            {
                Debug.Log("Probs first time set up");
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
        RandomChance = RandomChance/2 + _magic;
       
        if (RandomChance >= EpicThrehold)
        {

            float select = Random.Range(0, Epics.Length);
            return Epics[(int)select];
        }
        else if (RandomChance >= RareThreshold)
        {
            float select = Random.Range(0, Rares.Length);
            return Rares[(int)select];
        }
        else if (RandomChance >= UncommonThreshold)
        {
            float select = Random.Range(0, Uncommons.Length);
            return Uncommons[(int)select];
        }
        else if (RandomChance >= CommonThreshold)
        {
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
  