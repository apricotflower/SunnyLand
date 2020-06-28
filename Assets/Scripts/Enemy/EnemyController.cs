using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected Rigidbody2D rd;
    protected Animator anim;
    protected Collider2D colli;
    protected AudioSource source;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rd = GetComponent<Rigidbody2D>();
        colli = GetComponent<Collider2D>();
        source = GetComponent<AudioSource>();
    }
    

    public void Death()
    {
        Destroy(gameObject);//why no initialize gameObject?
    }

    public void JumpOn()
    {
        anim.SetTrigger("Death");
        source.Play();
    }
    
    
    
}
