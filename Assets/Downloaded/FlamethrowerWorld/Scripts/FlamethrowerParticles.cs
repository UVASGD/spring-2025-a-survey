
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class FlamethrowerParticles : UdonSharpBehaviour
{
    public ParticleSystem flameParticle;
    public AudioSource audioSource;
    [UdonSynced] bool isActive;
    private void FixedUpdate()
    {
        // RequestSerialization();
        if (!isActive)
        {
            audioSource.Pause();
            flameParticle.Stop();
            return;
        }
        if (!audioSource.isPlaying) audioSource.Play();
        if (!flameParticle.isPlaying) flameParticle.Play();
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
