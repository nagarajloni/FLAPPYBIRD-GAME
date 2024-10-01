using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;    // Maximum time between pipe spawns
    [SerializeField] private float _heightRange = 0.45f; // Range for random height of pipes
    [SerializeField] private GameObject _pipe;           // The pipe prefab to spawn

    private float _timer; // Timer to track time between pipe spawns

    private void Start()
    {
        SpawnPipe(); // Spawn the first pipe immediately
    }

    private void Update()
    {
        // Increment the timer
        _timer += Time.deltaTime;

        // Check if the timer has exceeded the maximum time
        if (_timer > _maxTime)
        {
            SpawnPipe(); // Spawn a new pipe
            _timer = 0;  // Reset the timer
        }
    }

    private void SpawnPipe()
    {
        // Calculate a random position for the pipe spawn
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));

        // Instantiate the pipe at the spawn position
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);

        // Destroy the pipe after 10 seconds
        Destroy(pipe, 10f);
    }
}
