using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zone_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    UI_Manager UIM;
    public float TriggerDistance;
    public string Zone;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
    }

    void SetZoneText()
    {
        if(Vector3.Distance(transform.position,Player.transform.position) < TriggerDistance)
        {

            if (UIM.ZoneText.GetComponentInChildren<Text>().text != Zone)
            {
                UIM.DisplayZone(Zone);
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        SetZoneText();
    }
}
