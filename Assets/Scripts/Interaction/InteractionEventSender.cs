using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class InteractionEventSender : MonoBehaviour
{
    public enum ActivationCriteria
    {
        Select,
        OnTriggerEnter,
        PushIn,
        RotateTo
    }

    public List<InteractionEventReciever> targets;

    //ontriggerenterscript
    public string triggerTag;

    public void ActivateTargets()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].Activate();
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(InteractionEventSender))]
[Serializable] public class InteractionEventSenderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
#endif