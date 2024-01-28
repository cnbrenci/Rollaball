using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private GameObject winTextObject;
    
    private Rigidbody _rb; 
    private float _movementX;
    private float _movementY;
    private int _count;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent <Rigidbody>();
        _count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame, before rendering a frame
    void Update()
    {
        
    }
    
    // FixedUpdate is called just before performing any physics calculations
    // This is where your physics code will go, like applying forces to RigidBody
    void FixedUpdate()
    {
        Vector3 movement = new Vector3 (_movementX, 0.0f, _movementY);
        _rb.AddForce(movement * speed);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        _movementX = movementVector.x; 
        _movementY = movementVector.y; 
    }

    void SetCountText()
    {
        countText.text = $"Count: {_count}";
        if (_count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            _count++;
            SetCountText();
        }
    }
}
