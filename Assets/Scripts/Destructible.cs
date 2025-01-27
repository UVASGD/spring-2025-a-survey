
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Testing.ArcheryKit
{
    public class Destructible : ArrowTargetBase
    {
        public GameObject destructedObject;

        protected override void _OnHit(ArrowProp arrow)
        {
            base._OnHit(arrow);
            GameObject destructed = Instantiate(destructedObject, transform.position, transform.rotation);

            var rbs = destructed.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs)
            {
                rb.AddExplosionForce(1000f, transform.position, 5);
            }

            Destroy(gameObject);
        }
    }

}