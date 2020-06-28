using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlogController : EnemyController
{
    
    public Transform left, right;
    public float leftX, rightX;
    private bool isFaceLeft = true;
    public float speed;
    public float jumpForce;
    public LayerMask ground;

    protected override void Start()
    {
        base.Start();
        leftX = left.position.x;
        rightX = right.position.x;
        Destroy(left.gameObject);
        Destroy(right.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movement();
        animChange();
    }

    public void Movement()
    {
        if (isFaceLeft)
        {
            rd.velocity = new Vector2(-speed,jumpForce);

        }
        else
        {
            rd.velocity = new Vector2(speed,jumpForce);

        }
    }

    private void animChange()
    {
        if (rd.velocity.y > 0)//jump
        {
            anim.SetBool("jumping",true);
        }else if (anim.GetBool("jumping"))//fall
        {
            anim.SetBool("jumping",false);
            anim.SetBool("falling",true);
        }else if (colli.IsTouchingLayers(ground))//idle
        {
            FaceDecideHelper();
            anim.SetBool("falling",false);
        }
    }

    private void FaceDecideHelper()
    {
        if (transform.position.x < leftX)
        {
            transform.localScale = new Vector3(-1,1,1);
            isFaceLeft = false;
        }

        if (transform.position.x > rightX)
        {
            transform.localScale = new Vector3(1,1,1);
            isFaceLeft = true;
        }
    }
}
