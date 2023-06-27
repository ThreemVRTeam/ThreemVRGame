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
        [Range(-180, 180)] [SerializeField] public int targetAngle = 150;
        private float targetValue = 0;
        private void Start()
        {
            knob = gameObject.GetComponent<XRKnob>();
            // map value, new value = (value - from1) / (to1 - from1) * (to2 - from2) + from2
            targetValue = ((float)targetAngle - -180) / (180 - -180) * (1 - 0) + 0;
        }
        public void CheckAngle()
        {
            if (knob != null)
            {
                Debug.Log($"Knob actual value:{knob.value}, Knob target value: {targetValue}");
                if (knob.value - targetValue < 0.05f)
                {
                    ActivateTargets();
                }
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