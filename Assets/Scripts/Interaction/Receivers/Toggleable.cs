using System;
using UnityEngine;

namespace Interaction
{
    public sealed class Toggleable : EventReceiver
    {
        [SerializeField] bool toggleKinematic = false;
        private new Rigidbody rigidbody;

        public override void InitialiseComponents()
        {
            if (toggleKinematic) rigidbody = GetComponent<Rigidbody>();
        }

        public override void Activate()
        {
            if (toggleKinematic) rigidbody.isKinematic = !rigidbody.isKinematic;
        }
    }
}

namespace Interaction.CustomInspector
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(Toggleable)), Serializable]
    public class ToggleableEditor : EventReceiverEditor { }
#endif
}