using System;
using UnityEngine;

namespace Interaction
{
    public abstract class EventReceiver : MonoBehaviour
    {
        public void Awake() => InitialiseComponents();

        /// <summary>
        /// Calls on Awake(), and should be called again if new components are required.
        /// </summary>
        public abstract void InitialiseComponents();

        /// <summary>
        /// Can be called by EventSender objects. This is the functionality of the EventReciever object.
        /// </summary>
        public abstract void Activate();
    }
}

namespace Interaction.CustomInspector
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(EventReceiver)), Serializable]
    public class EventReceiverEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EventReceiver script = (EventReceiver)target;

            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.Space();
                if (GUILayout.Button("Activate", EditorStyles.miniButton, GUILayout.MaxWidth(120))) script.Activate();
                EditorGUILayout.Space();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
        }
    }
#endif
}