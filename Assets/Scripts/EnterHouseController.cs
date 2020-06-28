using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouseController : MonoBehaviour
{
    // public BoxCollider2D colli;
    public GameObject enterPanel;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterPanel.SetActive(true);
            
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterPanel.SetActive(false);
        }
    }
    
}
