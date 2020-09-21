using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_Disappear : MonoBehaviour
{
    // Start is called before the first frame update
    public float StartScale;
    public float EndScale;
    float counter = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        transform.localScale = Vector3.Lerp(new Vector3(StartScale, StartScale, 1f), new Vector3(EndScale, EndScale, 1f), counter);
        if(counter >= 1)
        {
            Destroy(gameObject);
        }
    }
}
