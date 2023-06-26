using System;
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

namespace Interaction.CustomInspector
{
#if UNITY_EDITOR
    using UnityEditor;
    [CustomEditor(typeof(CollisionEventSender)), Serializable]
    public class CollisionEventSenderEditor : EventSenderEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
#endif
}