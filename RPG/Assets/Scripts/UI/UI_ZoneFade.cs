using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ZoneFade : MonoBehaviour
{
    // Start is called before the first frame update
    Text TxT;
    Color32 StartCol;
    float counter = 0f;
    void Start()
    {
        TxT = GetComponentInChildren<Text>();
        StartCol = TxT.color;

    }

    void Effect()
    {
        counter += Time.deltaTime;
       // TxT.color = Color.Lerp(Color.clear, Color.white, counter/2);
        if(counter >= 2)
        {
            counter = 0;
            TxT.text = "";
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Effect();
    }
}
