using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cam;
    public float moveRate;
    private float startPoint;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startPoint = cam.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        // if (transform.position.x < -0.6)
        // {
            transform.position = new Vector2(startPoint + moveRate * cam.position.x,transform.position.y);
        // }
    }
}
