using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_motor : MonoBehaviour
{
    // Start is called before the first frame update
    public float _speed;
    void Start()
    {
        
    }



    void Motion()
    {
        float Xpos = Input.GetAxisRaw("Horizontal");
        float Ypos = Input.GetAxisRaw("Vertical");
        Vector3 Direction = new Vector3(Xpos, Ypos, 0f);
        Direction *= _speed * Time.deltaTime;
        transform.position += Direction;
    }

    // Update is called once per frame
    void Update()
    {
        Motion();
    }
}
