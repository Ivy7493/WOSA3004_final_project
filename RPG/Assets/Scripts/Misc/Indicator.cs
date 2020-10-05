using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    // Start is called before the first frame update
    float counter = 0f;
    SpriteRenderer SR;
    GameObject Player;
    string Pos;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        SR = GetComponent<SpriteRenderer>();
    }

    public void SetDirection(string _pos)
    {
        Pos = _pos;
        
    }

    void Effect()
    {
        switch (Pos)
        {
            case "Right":
                transform.position = new Vector3(Player.transform.position.x + 4, Player.transform.position.y, 0f);
                break;
            case "Left":
                transform.position = new Vector3(Player.transform.position.x - 4, Player.transform.position.y, 0f);
                break;
            case "Up":
                transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 4, 0f);
                break;
            case "Down":
                transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 4, 0f);
                break;
        }
        counter += Time.deltaTime;
        SR.color = Color.Lerp(Color.clear, Color.white, counter);
        if(counter >= 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Effect();
    }
}
