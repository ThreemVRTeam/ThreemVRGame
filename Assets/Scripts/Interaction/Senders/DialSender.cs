using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.Content.Interaction;

namespace Interaction
{
    [RequireComponent(typeof(XRKnob))]
    public class DialSender : EventSender
    {
        [HideInInspector] public XRKnob knob;
        [Range(-180, 180)] public int targetAngle = 0;
        private float targetValue;
        private void OnEnable()
        {
            knob = GetComponent<XRKnob>();
            Assert.IsNotNull(knob, "No XR Knob component on dial, please add XR Knob component");
            // map value, new value = (value - from1) / (to1 - from1) * (to2 - from2) + from2
            targetValue = (targetAngle - -180) / (180 - -180) * (1 - 0) + 0;
        }
        public void CheckAngle()
        {
            if (knob.value - targetValue < 0.05)
            {
                ActivateTargets();
            }
        }
    }
}

namespace Interaction.CustomInspector
{
#if UNITY_EDITOR
    using UnityEditor;
    [CustomEditor(typeof(DialSender)), Serializable]
    public class DialSenderEditor : EventSenderEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
#endif
}