using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Event_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public string Message;
    public float Duration;
    public float Range;
    public bool SaveState = true;
    GameObject Player;
    UI_Manager UIM;
    void Start()
    {
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        Player = GameObject.FindGameObjectWithTag("Player");
        if(SaveState == true)
        {
            if(PlayerPrefs.GetFloat(gameObject.name,0f) != 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Player.transform.position,transform.position) <= Range)
        {
            UIM.SendNotification(Message, Duration);
            if(SaveState == true)
            {
                PlayerPrefs.SetFloat(gameObject.name, 1f);
            }
            Destroy(gameObject);
        }
    }
}
