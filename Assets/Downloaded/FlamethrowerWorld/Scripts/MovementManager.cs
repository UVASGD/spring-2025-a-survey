
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MovementManager : UdonSharpBehaviour
{
    public VRCPlayerApi pp;
    public float gravityStrength;
    public float jumpImpulse;
    void Start()
    {
        pp = Networking.LocalPlayer;
        pp.SetGravityStrength(gravityStrength);
        pp.SetJumpImpulse(jumpImpulse);
    }
}
