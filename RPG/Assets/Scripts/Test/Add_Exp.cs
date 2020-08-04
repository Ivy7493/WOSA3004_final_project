using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Exp : MonoBehaviour
{
    // Start is called before the first frame update
    Experience_Manager EM;
    void Start()
    {
        EM = GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EM.AddExp(10);
        }
    }
}
