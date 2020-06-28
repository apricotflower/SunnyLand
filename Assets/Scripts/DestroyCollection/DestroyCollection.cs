using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollection : MonoBehaviour
{
    protected Animator anim;
    protected string item;
        protected virtual void  Start()
        {
            anim = GetComponent<Animator>();
        }
    
        public void IsDestroied()
        {
            FindObjectOfType<PlayerController>().CollectionPlus(item);
            Destroy(gameObject);
        }
    
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                anim.SetTrigger("destroied");
            }
        }
}
