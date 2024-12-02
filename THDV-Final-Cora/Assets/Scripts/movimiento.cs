using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Rigidbody rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
       
        float horizontal = Input.GetAxisRaw("Horizontal"); 
        float vertical = Input.GetAxisRaw("Vertical"); 

        
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        rb.velocity = moveDirection * moveSpeed; 
    }
}

