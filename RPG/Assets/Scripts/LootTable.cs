using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LootTable : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Table;
    public float DropRate;
    GameObject Player;
    void Start()
    {
        
    }


    public void DropLoot()
    {
        float temp = Random.Range(0, 101);
        if (temp <= DropRate)
        {
            float select = Random.Range(0, Table.Length);
            Instantiate(Table[(int)select], transform.position, Quaternion.identity);
        }
    }

      
    // Update is called once per frame
    void Update()
    {

    }
}
