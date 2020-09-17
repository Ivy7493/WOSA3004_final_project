using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _player;
    float counter = 0;
    float PrevX, PrevY;
    void Start()
    {
        PrevX = Input.GetAxisRaw("Horizontal");
        PrevY = Input.GetAxisRaw("Vertical");
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10f);
    }


    void Motion()
    {
        float Xdiff = Input.GetAxis("Horizontal");
        float Ydiff = Input.GetAxis("Vertical");

        if (Xdiff != PrevX || Ydiff != PrevY)
        {
            counter = 0.35f;
        }
        PrevX = Xdiff;
        PrevY = Ydiff;


        counter += Time.deltaTime*2;
       

        transform.position = Vector3.Lerp(transform.position, new Vector3(_player.transform.position.x - Xdiff*1/3, _player.transform.position.y - Ydiff*1/3, -10f),counter);
        
        if(counter >= 1)
        {
            counter = 0.35f;
        }
        
       
       
        /*
        if(Xdiff != 0 || Ydiff != 0)
        {
            if(Xdiff != PrevY || Ydiff != PrevY)
            {
                counter = 0;
            }
            if (transform.position != new Vector3(_player.transform.position.x - Xdiff * 2, _player.transform.position.y - Ydiff * 2, -10f))
            {
                counter += Time.deltaTime;
                if(counter >= 1)
                {
                    counter = 1;
                }
                transform.position = Vector3.Lerp(transform.position, new Vector3(_player.transform.position.x - Xdiff * 2, _player.transform.position.y - Ydiff * 2, -10f), counter);
            }
        }else if(Xdiff == 0 && Ydiff == 0)
        {
            if (transform.position != new Vector3(_player.transform.position.x, _player.transform.position.y, -10f))
            {
                counter -= Time.deltaTime;
                if (counter <= 0)
                {
                    counter = 0;
                }
                transform.position = Vector3.Lerp(new Vector3(_player.transform.position.x, _player.transform.position.y, -10f),transform.position, counter);
            }
        }

        PrevX = Xdiff;
        PrevY = Ydiff;
       */
    }

    // Update is called once per frame
    void Update()
    {
        Motion();
    }
}
