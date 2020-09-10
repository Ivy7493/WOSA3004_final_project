using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    // Start is called before the first frame update
    public UI_Tutorial UIT;
    bool open = false;
    float counter = 3f;
    void Start()
    {
        
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
        if (Input.GetMouseButtonDown(0))
        {
            if(open == false)
            {
                UIT.activate_book_txt();
                open = true;
            }
           

        }
    }

    // Update is called once per frame
    void Update()
    {
        TickDown();
    }
}
