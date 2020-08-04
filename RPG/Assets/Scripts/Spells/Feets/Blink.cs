using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    public float Distance;
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        blink();
    }

    void blink()
    {
        float Xpos = Input.GetAxisRaw("Horizontal");
        float Ypos = Input.GetAxisRaw("Vertical");
        Vector3 Motion = new Vector3(Xpos, Ypos, 0f);
        Motion *= Distance;
        Player.transform.position += Motion;
        Debug.Log("Cast: Blink");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
