using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float speed;

    public float jumpForce;

    public Animator anim;

    public LayerMask ground;

    public Collider2D colli;
    
    public BoxCollider2D colliBox;

    public int cherryNum;
    
    public int gemNum;

    public Text cherryNumText;
    
    public Text gemNumText;

    public bool isHurted;

    public Transform cellingCheck,groundCheck;

    public bool canJump;

    private bool isGround;
    
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!isHurted)
        {
            Movement();
        }
        AnimationChange();
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);
    }

    public void Update()
    {
        Jump();
        Crouch();
    }

    // movement change condition
    private void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");//-1 left, 1 right, 0 no move
        float face = Input.GetAxisRaw("Horizontal");
        
        if (horizontalMove != 0)//can not use GetAxisRaw because it will always have speed
        {
            rb.velocity = new Vector2(horizontalMove * speed * Time.fixedDeltaTime, rb.velocity.y);
            
        }
        anim.SetFloat("running",Mathf.Abs(horizontalMove));

        if (face != 0 )
        {
            transform.localScale = new Vector3(face,1,1);
        }

        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);
            // jumpAudio.Play();
            SoundManager.soundManager.PlayAudio("jump");
            canJump = false;
        }
    }

    //animation Change condition
    private void AnimationChange()
    {
        if (rb.velocity.y > 0)
        {
            anim.SetBool("jumping",true);
        }else if(anim.GetBool("jumping"))
        {
            anim.SetBool("jumping",false);
            anim.SetBool("falling",true);
        }else if (colli.IsTouchingLayers(ground))
        {
            anim.SetBool("falling",false);
        }else if (!colli.IsTouchingLayers(ground))
        {
            anim.SetBool("falling",true);
        }

        //when the player stop
        if (Mathf.Abs(rb.velocity.x) < 0.6)
        {
            //if the reason of stopping is being hurted
            if (anim.GetBool("hurted"))
            {
                anim.SetBool("hurted",false);
                isHurted = false;
            }
        }
    }

    //update make the decision(faster), fixUpdate do the action(more stable)
    public void Jump()
    {
        if (Input.GetButton("Jump") && isGround)
        // if (Input.GetKey(KeyCode.Space) && colli.IsTouchingLayers(ground))
        {
            canJump = true;
        }
    }

    private void Crouch()
    {
        float isCrouch = Input.GetAxisRaw("Vertical");
        if (isCrouch == -1)
        {
            anim.SetBool("crouching",true);
            colliBox.offset = new Vector2(-0.05f,-0.5f);
            colliBox.size = new Vector2(0.5f,0.5f);
        } else if (isCrouch == 1)
        {
            if (!Physics2D.OverlapCircle(cellingCheck.position,0.2f,ground))
            {
                anim.SetBool("crouching",false);
                colliBox.offset = new Vector2(-0.07f,-0.15f);
                colliBox.size = new Vector2(1,1);
            }
        }
    }

    //collect items
    // public void OnTriggerEnter2D(Collider2D other)
    // {
        // if (other.tag == "cherry")
        // {
            // Destroy(other.gameObject);
            // cherryNum = cherryNum + 1;
            // cherryNumText.text = cherryNum.ToString();
            // collectAudio.Play();
        // }
        
        // if (other.tag == "gem")
        // {
        //     Destroy(other.gameObject);
        //     gemNum = gemNum + 1;
        //     gemNumText.text = gemNum.ToString();
        //     collectAudio.Play();
        // }
    // }

    // meet enemies
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy" )
        {
            if (anim.GetBool("falling"))
            {
                EnemyController enemyController = other.gameObject.GetComponent<EnemyController>();
                enemyController.JumpOn();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
            }
            else
            {
                isHurted = true;
                if (transform.position.x < other.gameObject.transform.position.x)
                {
                    rb.velocity = new Vector2(-5,rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(5,rb.velocity.y);
                }
                
                anim.SetBool("hurted",true);
                SoundManager.soundManager.PlayAudio("hurted");

            }

            
        }
    }

    public void CollectionPlus(string collection)
    {
        if (collection == "cherry")
        {
            cherryNum = cherryNum + 1;
            cherryNumText.text = cherryNum.ToString();
        }else if (collection == "gem")
        {
            gemNum = gemNum + 1;
            gemNumText.text = gemNum.ToString();
        }
        SoundManager.soundManager.PlayAudio("collection");
    }
}
