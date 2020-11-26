using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Fire;
    Game_Manager GM;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
    }

    void KeyActivate()
    {
        if(Fire == true)
        {
            GM.BossDefeated("FIRE");
        }else if(Fire == false)
        {
            GM.BossDefeated("FROST");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            KeyActivate();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
