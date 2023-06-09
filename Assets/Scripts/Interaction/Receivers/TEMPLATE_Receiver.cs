using System;

namespace Interaction
{
    public sealed class TEMPLATE_Receiver : EventReceiver
    {
        public override void InitialiseComponents()
        {
            
        }

        public override void Activate()
        {
            
        }
    }
}

namespace Interaction.CustomInspector
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(TEMPLATE_Receiver)), Serializable]
    public class DoorEditor : EventReceiverEditor { }
#endif
}