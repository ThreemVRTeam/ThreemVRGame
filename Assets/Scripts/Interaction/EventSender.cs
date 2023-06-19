using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Interaction
{
    public class EventSender : MonoBehaviour
    {
        [SerializeField] List<GameObject> eventReceiverObjects;
        [HideInInspector] public List<EventReceiver> targets;

        private void Awake()
        {
            FindEventReceivers();
        }

        /// <summary>
        /// Calls on Awake(), and should be called again if the eventReceiverObjects list is updated.
        /// </summary>
        public void FindEventReceivers()
        {
            foreach (var eventReceiverObject in eventReceiverObjects)
            {
                List<EventReceiver> eventReceivers = eventReceiverObject.GetComponents<EventReceiver>().ToList();

                foreach (var eventReceiver in eventReceivers)
                    targets.Add(eventReceiver);
                eventReceivers.Clear();
            }
        }

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