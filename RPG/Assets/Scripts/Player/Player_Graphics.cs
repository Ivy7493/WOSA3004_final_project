using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Graphics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Rotate()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        // Update is called once per frame
        
    }

    private void Update()
    {
        Rotate();
    }
}
