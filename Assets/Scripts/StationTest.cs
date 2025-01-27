
using UdonSharp;
using UnityEngine;
using VRC.Economy;
using VRC.SDK3.ClientSim;
using VRC.SDKBase;
using VRC.Udon;

public class StationTest : UdonSharpBehaviour
{
    private Vector3 startPosition;
    private float timer = 0f;
    private float moveSpeed = 1f; // Adjust this to control movement speed
    private float moveDistance = 3f; // Distance to move left/right
    void Start()
    {
        startPosition = transform.position;
    }
    public override void Interact()
    {
        Networking.LocalPlayer.UseAttachedStation();
    }

    public override void OnStationEntered(VRCPlayerApi player)
    {
        Debug.Log($"{player.displayName} Entered");
    }

    public override void OnStationExited(VRCPlayerApi player)
    {
        Debug.Log($"{player.displayName} Exited");
    }

    private void Update()
    {
        // Increment timer
        timer += Time.deltaTime * moveSpeed;

        // Calculate the new x position using a sine wave for smooth back-and-forth movement
        float newX = startPosition.x + Mathf.Sin(timer) * moveDistance;

        // Update position
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
