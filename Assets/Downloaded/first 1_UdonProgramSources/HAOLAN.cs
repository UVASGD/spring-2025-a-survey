
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class HAOLAN : UdonSharpBehaviour
{
    [SerializeField] float rotationSpeed;
    Quaternion rotationGoal;
    Vector3 direction;

    private void Update()
    {
        direction = (Networking.LocalPlayer.GetPosition() - transform.position).normalized;
        //transform.LookAt(Networking.LocalPlayer.GetPosition());
        //transform.RotateAround(Networking.LocalPlayer.GetPosition(), Vector3.up, 20 * Time.deltaTime);
        rotationGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotationSpeed);
    }

    void PivotTo(Vector3 position)
    {
        Vector3 offset = transform.position - position;
        foreach (Transform child in transform)
            child.transform.position += offset;
        transform.position = position;
    }
}
