
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class LobbyStartButton : UdonSharpBehaviour
{
    [SerializeField] private Transform targetPosition;

    public override void Interact()
    {
        Networking.LocalPlayer.TeleportTo(targetPosition.position, targetPosition.rotation);
    }
}
