
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Serialization.OdinSerializer.Utilities;

public class RepositionFlamethrowers : UdonSharpBehaviour
{
    public VRCPickup[] flamethrowers;
    public Transform spawnPosition;
    public override void Interact()
    {
        for (int i = 0; i < flamethrowers.Length; i++)
        {
            var flamethrower = flamethrowers[i];

            if (flamethrower.IsHeld) { break; }
            flamethrower.transform.position = spawnPosition.position;
            flamethrower.transform.rotation = Quaternion.identity;
        }
    }
}
