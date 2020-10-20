using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Graphics : MonoBehaviour
{
    Animator playeranim;
    Animator UpAnim;
    Animator DownAnim;
    Animator SideAnim;
    public Rigidbody2D RB;
    public GameObject Up;
    public GameObject Down;
    public GameObject Side;
    SpriteRenderer[] Renderers;

    Vector3 UpOffset;
    Vector3 DownOffset;
    Vector3 SideOffset;
    Vector3 NullOffset = new Vector3(1000, 1000, 0f);
    // Start is called before the first frame update
    void Start()
    {
        playeranim = GetComponent<Animator>();
        UpAnim = Up.GetComponent<Animator>();
        DownAnim = Down.GetComponent<Animator>();
        SideAnim = Side.GetComponent<Animator>();
        UpOffset = Up.transform.localPosition;
        DownOffset = Down.transform.localPosition;
        SideOffset = Side.transform.localPosition;
        Renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    public void ResetPlayerColor()
    {
        for(int i = 0; i < Renderers.Length; i++)
        {
            Renderers[i].color = Color.white;
        }
    }

    void AnimationManagement()
    {
        if ((Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0))
        {
            playeranim.SetBool("running", false);
        }
        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            playeranim.SetBool("running", true);
        } 
    }

    void Rotate()
    {
        if (Input.GetAxisRaw("Horizontal") >= 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            playeranim.SetBool("running", true);

        }
        else if (Input.GetAxisRaw("Horizontal") <= -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            playeranim.SetBool("running", true);
        }


        // Update is called once per frame
        
    }

    void SetActiveGraphic(string _Direction)
    {
        switch (_Direction)
        {
            case "Up":
                Up.transform.localPosition = UpOffset;
                Side.transform.localPosition = NullOffset;
                Down.transform.localPosition = NullOffset;
                break;
            case "Down":
                Down.transform.localPosition = DownOffset;
                Side.transform.localPosition = NullOffset;
                Up.transform.localPosition = NullOffset;
                break;
            case "Side":
                Side.transform.localPosition = SideOffset;
                Down.transform.localPosition = NullOffset;
                Up.transform.localPosition = NullOffset;
                break;
        }
    }

    void SpriteManagement()
    {
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            
          //  Down.SetActive(false);
            //Side.SetActive(false);
            //Up.SetActive(true);
            SetActiveGraphic("Up");
        }
        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            //Up.SetActive(false);
            //Side.SetActive(false);
            //Down.SetActive(true);
            SetActiveGraphic("Down");
        }
        else
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
          //  Up.SetActive(false);
          //  Down.SetActive(false);
          //  Side.SetActive(true);
            SetActiveGraphic("Side");
            Side.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            SideAnim.SetBool("running", true);
        }
        else if(Input.GetAxisRaw("Horizontal") == -1)
        {
            //Up.SetActive(false);
           // Down.SetActive(false);
          //  Side.SetActive(true);
            SetActiveGraphic("Side");
            Side.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            SideAnim.SetBool("running", true);
        }
        if(Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            
            //Up.SetActive(false);
            //Down.SetActive(false);
            //Side.SetActive(true);
            SetActiveGraphic("Side");
            //  Side.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            SideAnim.SetBool("running", false);
           
        }
    }
    private void Update()
    {
        if(GetComponentInParent<Player_motor>().ReturnStunStatus() == false)
        {
            SpriteManagement();
        }
       
      //  Rotate();
     //   AnimationManagement();
    }
}
