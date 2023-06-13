using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.Content.Interaction;

namespace Interaction
{

    public class DialSender : EventSender
    {
        [HideInInspector] public XRKnob knob;
        public float targetAngle = 0;
        private float targetValue;
        private void OnEnable()
        {
            knob = GetComponent<XRKnob>();
            Assert.IsNotNull(knob, "No XR Knob component on dial, please add XR Knob component");
            // map value, new value = (value - from1) / (to1 - from1) * (to2 - from2) + from2
            targetValue = (targetAngle - -180) / (180 - -180) * (1 - 0) + 0;
            Debug.Log($"Target Value: {targetValue}");
        }
        public void CheckAngle()
        {
            if (knob.value - targetValue < 0.05)
            {
                Debug.Log("Hitting Target Value");
            }
        }
    }
}
namespace Interaction.CustomInspector
{
    using Unity.VisualScripting;
    using UnityEditor;

    [CustomEditor(typeof(DialSender)), Serializable]
    public class DialSenderEditor : Editor
    {

        public DialSender dialSender;
        public XRKnob knob;
        private SerializedProperty targetAngle;
        public void OnEnable()
        {
            dialSender = target.GetComponent<DialSender>();
            Assert.IsNotNull(dialSender, "No XR Knob component on dial, please add XR Knob component");
            knob = target.GetComponent<XRKnob>();
            targetAngle = serializedObject.FindProperty("targetAngle");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.LabelField("Target Angle: ");
            EditorGUILayout.IntSlider((int)targetAngle.floatValue, (int)knob.minAngle, (int)knob.maxAngle);
            serializedObject.ApplyModifiedProperties();
        }
    }

}
