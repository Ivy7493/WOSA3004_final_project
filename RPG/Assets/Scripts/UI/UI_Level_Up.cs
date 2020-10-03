using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Level_Up : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI txt;
    Color32 StartCol;
    float counter = 0f;
    bool Switch = true;
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        StartCol = txt.color;
    }

    // Update is called once per frame
    void Update()
    {

        if(Switch == false)
        {
            counter += Time.unscaledDeltaTime / 2;
            txt.color = Color.Lerp(StartCol, Color.clear, counter);
            if (counter >= 1)
            {
                counter = 0;
                txt.color = StartCol;
                Switch = true;
                gameObject.SetActive(false);
            }
        }else if(Switch == true)
        {
            counter += Time.unscaledDeltaTime / 2;
            txt.color = Color.Lerp(Color.clear, StartCol, counter);
            if(counter >= 1)
            {
                counter = 0f;
                Switch = false;
            }
        }
       
    }
}
