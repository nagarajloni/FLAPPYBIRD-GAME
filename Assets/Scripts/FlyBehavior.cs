using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Ensure the Input System package is installed

public class FlyBehavior : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;       // Upward force applied when clicked
    [SerializeField] private float _rotationSpeed = 10f;   // Speed for rotation based on vertical velocity

    private Rigidbody2D _rb;

    private void Start()
    {
        // Assign the Rigidbody2D component to _rb
        _rb = GetComponent<Rigidbody2D>();

        // Check if _rb is assigned correctly
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the GameObject. Please add it in the Inspector.");
        }
    }

    private void Update()
    {
        // Detect mouse click or screen tap to make the bird fly up
        if (Input.GetMouseButtonDown(0)) // 0 corresponds to the left mouse button or screen tap
        {
            Debug.Log("Mouse clicked, applying upward force: " + _velocity);

            // Apply upward velocity
            _rb.velocity = Vector2.up * _velocity;
        }
    }

    private void FixedUpdate()
    {
        // Adjust the bird's rotation based on its vertical velocity
        float angle = -_rb.velocity.y * _rotationSpeed; // Calculate rotation angle
        transform.rotation = Quaternion.Euler(0, 0, angle); // Set rotation
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for collision and ensure GameManager is referenced correctly
        if (GameManager.instance != null)
        {
            Debug.Log("Collision detected, triggering Game Over.");
            GameManager.instance.GameOver();
        }
        else
        {
            Debug.LogError("GameManager instance is not set. Make sure GameManager.instance is assigned properly.");
        }
    }
}
