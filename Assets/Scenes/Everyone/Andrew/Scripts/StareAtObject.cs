using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class StareAtObject : UdonSharpBehaviour
{
    private VRCPlayerApi localPlayer;
    public float rotationSpeed = 5f; 

    private void Start()
    {
        localPlayer = Networking.LocalPlayer;
    }

    void Update()
    {
        if (!Utilities.IsValid(localPlayer)) return;

        Vector3 targetPosition = localPlayer.GetBonePosition(HumanBodyBones.Head);
        Vector3 directionToLook = (targetPosition - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToLook) * Quaternion.Euler(0, 180, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
