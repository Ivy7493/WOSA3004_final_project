using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Damage_Effect : MonoBehaviour
{
    // Start is called before the first frame update
    float counter = 0f;
    Color32 StartCol;
    public float EffectDuration;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        StartCol = GetComponent<Image>().color;
    }

    private void OnDisable()
    {
        counter = 0f;
        GetComponent<Image>().color = StartCol;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        GetComponent<Image>().color = Color.Lerp(StartCol, Color.clear, counter/EffectDuration);
        if(counter >= EffectDuration)
        {
            gameObject.SetActive(false);
        }
    }
}
