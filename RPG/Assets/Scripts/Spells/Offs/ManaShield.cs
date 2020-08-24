using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaShield : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    public float HitCount;
    SpriteRenderer SR;
    float counter;
    bool Switch = false;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        SR = GetComponent<SpriteRenderer>();
    }

    void Spell()
    {
        Debug.Log("Working");
        transform.position = Player.transform.position;
        switch (Switch)
        {
            case false:
                counter += Time.deltaTime;
                SR.color = Color.Lerp(new Color32(0, 253, 237, 150), new Color32(0, 253, 237, 112), counter);
                if(counter >= 1)
                {
                    counter = 0;
                    Switch = true;
                }
                break;
            case true:
                counter += Time.deltaTime;
                SR.color = Color.Lerp(new Color32(0, 253, 237, 112),new Color32(0, 253, 237, 150), counter);
                if(counter >= 1)
                {
                    counter = 0;
                    Switch = false;
                }

                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.tag == "Damagable")
        {
            HitCount--;
            if (HitCount <= 0)
            {
                Destroy(gameObject);
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        Spell();
    }
}
