using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_motor : MonoBehaviour
{
    // Start is called before the first frame update
    public float _speed;

    private void Awake()
    {
        LoadPlayerPosition();
    }
    void Start()
    {
        
    }


    void LoadPlayerPosition()
    {
        float Xpos = PlayerPrefs.GetFloat("Xpos", 0);
        float Ypos = PlayerPrefs.GetFloat("Ypos", 0);
        transform.position = new Vector3(Xpos, Ypos, 0f);
    }


    void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat("Ypos", transform.position.y);
        PlayerPrefs.SetFloat("Xpos", transform.position.x);
    }



    void Motion()
    {
        float Xpos = Input.GetAxisRaw("Horizontal");
        float Ypos = Input.GetAxisRaw("Vertical");
        Vector3 Direction = new Vector3(Xpos, Ypos, 0f);
        Direction *= _speed * Time.deltaTime;
        transform.position += Direction;
    }

    private void OnApplicationQuit()
    {
        SavePlayerPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Motion();
    }
}
