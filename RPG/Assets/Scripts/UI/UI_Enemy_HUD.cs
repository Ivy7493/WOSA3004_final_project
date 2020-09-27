using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Enemy_HUD : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bar;
    public GameObject BarSprite;
    Color32 Startcol;
    void Start()
    {
        Startcol = BarSprite.GetComponent<SpriteRenderer>().color;
        InvokeRepeating("FlashHealth", 0f, 0.1f);
    }

    void FlashHealth()
    {
        if(Bar.transform.localScale.x <= 0.3f)
        {
          SpriteRenderer SR = BarSprite.GetComponent<SpriteRenderer>();
           if(SR.color == Startcol)
            {
                SR.color = Color.white;
            }else if(SR.color != Startcol)
            {
                SR.color = Startcol;
            }
        }
    }


    public void UpdateHealthBar(float _percent)
    {
        if(_percent < 0)
        {
            _percent = 0;
        }
        Bar.transform.localScale = new Vector3(_percent, 1, 1);
       
    }


    // Update is called once per frame
  
}
