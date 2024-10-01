using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeIncreaseScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered by: " + collision.gameObject.name);
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided, updating score");
            Score.instance.UpdateScore();  // Update score on collision with the player
        }
    }
}
