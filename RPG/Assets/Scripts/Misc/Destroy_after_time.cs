using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_after_time : MonoBehaviour
{
    // Start is called before the first frame update
    float time = 0.3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time < 0f)
        {
            Destroy(gameObject);
        }
    }
}
