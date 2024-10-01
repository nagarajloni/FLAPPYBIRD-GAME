using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float _speed = 0.65f;

    private void Update()
    {
        // Move the pipe to the left at the specified speed
        transform.position += Vector3.left * _speed * Time.deltaTime; // Add the semicolon here
    }
}
