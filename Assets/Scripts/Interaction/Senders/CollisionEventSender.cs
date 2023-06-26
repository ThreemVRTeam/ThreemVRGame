using UnityEngine;

namespace Interaction
{
    public class CollisionEventSender : EventSender
    {
        private void OnTriggerEnter(Collider other)
        {
            foreach (var eventReceiverObject in eventReceiverObjects)
                if (other.gameObject == eventReceiverObject) ActivateTargets();
        }
    }
}