using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Damage_text_Effect : MonoBehaviour
{
    // Start is called before the first frame update
    float counter = 0f;
    Vector3 StartPos;
    Vector3 EndPos;
    TextMeshPro Txt;
    Color32 StartCol;
    void Start()
    {
        StartPos = transform.position;
        EndPos = new Vector3(StartPos.x, StartPos.y + 2f, 0f);
        Txt = GetComponent<TextMeshPro>();
        StartCol = Txt.color;
    }

    public void IsCrit()
    {
        StartCol = Color.red;
        Txt.color = Color.red;
        Txt.fontSize *= 2f;
        Debug.Log("OOOOOOOO");
    }

    void Effect()
    {
        counter += Time.deltaTime*2;
        transform.position = Vector3.Lerp(StartPos, EndPos, counter);
        Txt.color = Color.Lerp(StartCol, Color.clear, counter/2);
        if(counter >= 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Effect();
    }
}
