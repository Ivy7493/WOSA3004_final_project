using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    // Start is called before the first frame update
    public UI_Tutorial UIT;
    bool open = false;
    void Start()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(open == false)
            {
                UIT.activate_book_txt();
                open = true;
            }else if(open == true)
            {
                UIT.deactivate_book_txt();
                open = false;
            }
          

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
