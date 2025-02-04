
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Hover : UdonSharpBehaviour
{
    [SerializeField] private float amplitude = 0.5f; // Maximum distance to move up/down
    [SerializeField] private float frequency = 1f; // Speed of oscillation

    private Vector3 startPosition;
    private float time;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        time += Time.deltaTime;

        // Calculate the simple harmonic motion
        float displacement = amplitude * Mathf.Sin(time * frequency * 2f * Mathf.PI);

        // Apply the new position
        Vector3 newPosition = startPosition + Vector3.up * displacement;
        transform.position = newPosition;
    }
}
