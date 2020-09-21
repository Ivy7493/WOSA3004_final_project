using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_Mover : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FrostRain;
    public float Duration;
    public float Speed;
    public float TickRate;
    GameObject Player;
    Vector3 direction;
    float counter = 0f;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        direction = (Player.transform.position - transform.position).normalized;
        InvokeRepeating("Spell", 0f, TickRate);
    }

    void Spell()
    {
        for(int i = 0; i < 4; i++)
        {
            float Randx;
            float Randy;
            Randx = Random.Range(-2, 3f);
            Randy = Random.Range(-2, 3f);
            Instantiate(FrostRain, new Vector3(transform.position.x + Randx - 4, transform.position.y + 10f + Randy, 0f), Quaternion.Euler(0f,0f,165f));
        }

    }

    void Motion()
    {
        transform.position += direction * Speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        Motion();
        if(counter >= Duration)
        {
            Destroy(gameObject);
        }
    }
}
