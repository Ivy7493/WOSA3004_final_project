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
    // Start is called before the first frame update
    void Start()
    {
        playeranim = GetComponent<Animator>();
        UpAnim = Up.GetComponent<Animator>();
        DownAnim = Down.GetComponent<Animator>();
        SideAnim = Side.GetComponent<Animator>();
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

    void SpriteManagement()
    {
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            
            Down.SetActive(false);
            Side.SetActive(false);
            Up.SetActive(true);
        }
        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            Up.SetActive(false);
            Side.SetActive(false);
            Down.SetActive(true);
        }
        else
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            Up.SetActive(false);
            Down.SetActive(false);
            Side.SetActive(true);
            Side.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            SideAnim.SetBool("running", true);
        }
        else if(Input.GetAxisRaw("Horizontal") == -1)
        {
            Up.SetActive(false);
            Down.SetActive(false);
            Side.SetActive(true);
            Side.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            SideAnim.SetBool("running", true);
        }
        if(Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            Up.SetActive(false);
            Down.SetActive(false);
            Side.SetActive(true);
            Side.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            SideAnim.SetBool("running", false);
        }
    }
    private void Update()
    {
        SpriteManagement();
      //  Rotate();
     //   AnimationManagement();
    }
}
