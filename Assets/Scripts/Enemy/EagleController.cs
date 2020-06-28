using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : EnemyController
{
    public Transform top,down;
    public float topY, downY;
    private bool towardsUp = true;
    public float speed;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        topY = top.position.y;
        downY = down.position.y;
        Destroy(top.gameObject);
        Destroy(down.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (towardsUp)
        {
            rd.velocity = new Vector2(rd.velocity.x,speed);
        }
        else
        {
            rd.velocity = new Vector2(rd.velocity.x,-speed);
        }
        
        if (transform.position.y > topY)
        {
            towardsUp = false;
        }

        if (transform.position.y < downY)
        {
            towardsUp = true;
        }
    }
}
