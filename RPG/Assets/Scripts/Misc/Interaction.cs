using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // Start is called before the first frame update
    UI_Manager UIM;
    void Start()
    {
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
    }

    private void OnMouseEnter()
    {
        UIM.CallInteractionDisplay(new Vector3(transform.position.x,transform.position.y - 6f,0f));
    }

    private void OnMouseExit()
    {
        UIM.DestroyInteractionDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
