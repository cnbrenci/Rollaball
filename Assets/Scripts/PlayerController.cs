using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    
    private Rigidbody _rb; 
    private float movementX;
    private float movementY;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent <Rigidbody>(); 
    }

    // Update is called once per frame, before rendering a frame
    void Update()
    {
        
    }
    
    // FixedUpdate is called just before performing any physics calculations
    // This is where your physics code will go, like applying forces to RigidBody
    void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        _rb.AddForce(movement * speed);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }
}
