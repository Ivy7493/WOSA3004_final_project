using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _player;
    void Start()
    {
        
    }


    void Motion()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        Motion();
    }
}
