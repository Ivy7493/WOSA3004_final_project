using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Up_Destory : MonoBehaviour
{
    // Start is called before the first frame update
    public float Duration;
    public float OffsetX, OffsetY;
    GameObject Player;
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x + OffsetX, Player.transform.position.y + OffsetY, 0f);
        Duration -= Time.deltaTime;
        if(Duration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
