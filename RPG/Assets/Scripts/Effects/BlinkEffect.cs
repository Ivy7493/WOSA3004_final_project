using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer SR;
    float counter;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();

    }


    void Effet()
    {
        counter += Time.deltaTime;
        SR.color = Color.Lerp(Color.blue, Color.clear, counter);
        if(counter >= 1)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Effet();
    }
}
