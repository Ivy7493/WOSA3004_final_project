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
    public float Range;
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
       if(Vector3.Distance(Player.transform.position,transform.position) < Range)
        {
            GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>().Damage(GameObject.FindGameObjectWithTag("Resource_Manager").GetComponent<Resource_Manager>().ReturnCurrentHP()/10);
        }

    }

    void FuckUnity()
    {
        transform.Rotate(0f, 0f, 360 * Time.deltaTime);
    }

    void Motion()
    {
        transform.position += direction * Speed * Time.deltaTime;
        FuckUnity();
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
