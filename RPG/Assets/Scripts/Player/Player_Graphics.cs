using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Graphics : MonoBehaviour
{
    Animator playeranim;
    public Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        playeranim = GetComponent<Animator>();
    }

    void AnimationManagement()
    {
        if (RB.velocity.magnitude == 0)
        {
            playeranim.SetBool("running", false);
        }
        if (RB.velocity.magnitude > 0 || RB.velocity.magnitude < 0)
        {
            playeranim.SetBool("running", true);
        } 
    }

    void Rotate()
    {
        if (RB.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            playeranim.SetBool("running", true);

        }
        else if (RB.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            playeranim.SetBool("running", true);
        }


        // Update is called once per frame
        
    }

    private void Update()
    {
        Rotate();
        AnimationManagement();
    }
}
