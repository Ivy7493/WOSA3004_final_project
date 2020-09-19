using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite DefaultCursor;
    public Sprite ItemCursor;
    Vector3 TargetLocation;
    SpriteRenderer SR;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.sprite = DefaultCursor;
        Cursor.visible = false;
        
    }

    public void SwitchCursor(string _State)
    {
        switch (_State)
        {
            case "Item":
                SR.sprite = ItemCursor;
                break;
            case "Default":
                SR.sprite = DefaultCursor;
                break;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        TargetLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(TargetLocation.x, TargetLocation.y, 0f);
    }
}
