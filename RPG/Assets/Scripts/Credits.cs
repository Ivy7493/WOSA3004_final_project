using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Credits : MonoBehaviour
{

    float countdown = 26f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void transition()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= 1 * Time.deltaTime;

        if (countdown <= 0)
        {
            transition();
        }
    }
}
