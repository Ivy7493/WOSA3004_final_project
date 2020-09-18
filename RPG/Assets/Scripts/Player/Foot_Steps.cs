using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot_Steps : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FootStep1;
    public GameObject FootStep2;
    public Rigidbody2D RB;
    bool Change = false;
    public float StepTiming;
    float counter;
    void Start()
    {
        
    }


    void StepSound()
    {
        counter += Time.deltaTime;
        switch (Change)
        {
            case false:
                if (counter >= StepTiming && RB.velocity.magnitude != 0)
                {
                    counter = 0;
                    Change = true;
                    Instantiate(FootStep1, transform.position, Quaternion.identity);
                }
                break;
            case true:
                if (counter >= StepTiming && RB.velocity.magnitude != 0)
                {
                    counter = 0;
                    Change = false;
                    Instantiate(FootStep2, transform.position, Quaternion.identity);
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StepSound();
    }
}
