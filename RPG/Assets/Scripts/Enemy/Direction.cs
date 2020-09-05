using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 CurrentPos;
    Vector3 Previous;
    void Start()
    {
        CurrentPos = transform.position;
        Previous = transform.position;
    }

    void Dir()
    {
        Previous = CurrentPos;
        CurrentPos = transform.position;
        if((CurrentPos.x - Previous.x) < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }else if((CurrentPos.x - Previous.x) > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Dir();
    }
}
