using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer SR;
    LootTable LT;
    public Sprite ChestOpen;
    float counter = 0.5f;
    bool Opened = false;
    void Start()
    {
        LT = GetComponent<LootTable>();
        SR = GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Opened = true;
            SR.sprite = ChestOpen;
        }
    }

    void ChestLogic()
    {
        if(Opened == true)
        {
            counter -= Time.deltaTime;
            if(counter <= 0)
            {
                LT.DropLoot();
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChestLogic();
    }
}
