using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffectPlayerFade : MonoBehaviour
{
    public GameObject BlinkScript;
    public Blink BlinkScr;
    public float timeBetweenSpawns;
    public float startTimeBetweenSpawns;

    public GameObject echo;

    // Start is called before the first frame update
    void Start()
    {
        BlinkScr = GameObject.FindGameObjectWithTag("Blink_feet").GetComponent<Blink>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BlinkScr.ReturnIsBlinking())
        {
            if (timeBetweenSpawns <= 0)
            {
                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, 5f);
                timeBetweenSpawns = startTimeBetweenSpawns;
            }
            else
            {
                timeBetweenSpawns -= Time.deltaTime;
            }
        }
        
    }
}
