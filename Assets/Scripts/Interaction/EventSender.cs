using System;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class EventSender : MonoBehaviour
    {
        [SerializeField] private List<EventReceiver> targets;

        /// <summary>
        /// Sends an Activate() message to all targets specified in the inspector.
        /// </summary>
        public virtual void ActivateTargets()
        {
            foreach (EventReceiver target in targets)
            {
                // null proof
                if (target != null)
                    target.Activate();
            }
        }
    }
}

namespace Interaction.CustomInspector
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(EventSender)), Serializable]
    public class EventSenderEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EventSender script = (EventSender)target;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            if (GUILayout.Button("Activate Targets", EditorStyles.miniButton, GUILayout.MaxWidth(120))) script.ActivateTargets();
            EditorGUILayout.Space();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
        }
    }
#endif
}