using System;

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
namespace Interaction.CustomInspector
{
#if UNITY_EDITOR
    using UnityEditor;
    [CustomEditor(typeof(ButtonSender)), Serializable]
    public class ButtonSenderEditor : EventSenderEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
#endif
}