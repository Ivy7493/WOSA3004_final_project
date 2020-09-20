using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    // Start is called before the first frame update
    public UI_Tutorial UIT;
    Cursor_Manager CM;
    bool open = false;
    float counter = 3f;
    void Start()
    {
        CM = GameObject.FindGameObjectWithTag("Cursor_Manager").GetComponent<Cursor_Manager>();
    }


    void TickDown()
    {
        if(open == true)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                open = false;
                UIT.deactivate_book_txt();
            }
        }
       
    }

    

    private void OnMouseOver()
    {
        CM.SwitchCursor("Item");
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(open == false)
            {
                UIT.activate_book_txt();
                open = true;
            }
           

        }
    }

    private void OnMouseExit()
    {
        CM.SwitchCursor("Default");
    }

    // Update is called once per frame
    void Update()
    {
        TickDown();
    }
}
