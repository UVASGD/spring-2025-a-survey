
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class FlamethrowerMovement : UdonSharpBehaviour
{
    public VRCPlayerApi playerLocal;

    public float maxSpeed;
    public float walkSpeed;
    public float strafeSpeed;

    private bool isActive;
    [SerializeField] private float ammo;
    public float drainRate;

    void Start()
    {
        playerLocal = Networking.LocalPlayer;
    }

    private void FixedUpdate()
    {
        // RequestSerialization();
        if (!isActive)
        {
            SetWalkAndStrafeSpeed(5f, 5f);
            return;
        }

        //ammo -= drainRate;
        //ammo = ammo < 0 ? 0 : ammo;
        //Debug.Log($"ammo: {ammo}");

        PropelPlayer();
        SetWalkAndStrafeSpeed(walkSpeed, strafeSpeed);

    }

    public void PropelPlayer()
    {
        playerLocal.SetVelocity(Vector3.ClampMagnitude(playerLocal.GetVelocity() + -transform.forward, maxSpeed));
    }

    public void SetWalkAndStrafeSpeed(float walk, float strafe)
    {
        playerLocal.SetWalkSpeed(walk);
        playerLocal.SetStrafeSpeed(strafe);
    }

    public override void OnPickupUseDown()
    {
        isActive = true;
    }

    public override void OnPickupUseUp()
    {
        isActive = false;
    }


}
