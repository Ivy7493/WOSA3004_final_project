using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_effect : MonoBehaviour
{

    // Start is called before the first frame update
    float counter = 0;
    SpriteRenderer SR;
    Color32 StartCol;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        StartCol = SR.color;
    }


    void effect()
    {
        counter += Time.deltaTime;
        transform.localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 1), Vector3.zero, counter);
        SR.color = Color32.Lerp(Color.cyan, Color.clear, counter);
        if (counter >= 1)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        effect();
    }
}
