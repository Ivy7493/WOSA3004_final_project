using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Talents_Flash : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI txt;
    Color32 StartColor;
    float counter = 0f;
    bool Change = false;
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        StartColor = txt.color;
    }

    void Effect()
    {
        switch (Change)
        {
            case false:
                counter += Time.deltaTime;
                txt.color = Color.Lerp(StartColor, Color.red, counter);
                if(counter >= 1)
                {
                    counter = 0;
                    Change = true;
                }
                break;
            case true:
                counter += Time.deltaTime;
                txt.color = Color.Lerp(Color.red, StartColor, counter);
                if(counter >= 1)
                {
                    counter = 0f;
                    Change = false;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Effect();
    }
}
