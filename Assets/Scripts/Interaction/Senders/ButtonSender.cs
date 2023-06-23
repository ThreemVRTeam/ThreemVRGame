using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class ButtonSender : EventSender
    {
        public override void ActivateTargets()
        {
            base.ActivateTargets();
        }
    }
}
namespace Interaction.CustomInspectors
{
#if UNITY_EDITOR
    using UnityEditor;
    [CustomEditor(typeof(ButtonSender))]
    public class ButtonSenderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
#endif
}
