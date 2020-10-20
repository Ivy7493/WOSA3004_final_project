using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Indicator : MonoBehaviour
{
    // Start is called before the first frame update
    float Scale;
    float _Time;
    bool set = false;
    float counter = 0f;
    SpriteRenderer SR;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    void Indicator()
    {
        if(set == true)
        {
            counter += Time.deltaTime;
            SR.color = Color.Lerp(Color.clear, Color.white, counter / _Time);
            if(counter >= _Time)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetIndicator(float time, float scale)
    {
        _Time = time;
        Scale = scale;
        transform.localScale = new Vector3(2*scale, 2*scale, 1f);
        set = true;
    }

    // Update is called once per frame
    void Update()
    {
        Indicator();
    }
}
