using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LootTable : MonoBehaviour
{
    // Start is called before the first frame update
    public float MagicFind;
    
    void Start()
    {
        
    }


    public void DropLoot()
    {
        /*
        float temp = Random.Range(0, 101);
        if (temp <= DropRate)
        {
            float select = Random.Range(0, Table.Length);
            Instantiate(Table[(int)select], transform.position, Quaternion.identity);
        }
        */
        GameObject Loot = GameObject.FindGameObjectWithTag("Loot_Manager").GetComponent<Loot_Manager>().ReturnLoot(MagicFind);
        if(Loot != null)
        {
            Instantiate(Loot, transform.position, Quaternion.identity);
        }
        
    }

      
    // Update is called once per frame
    void Update()
    {

    }
}
