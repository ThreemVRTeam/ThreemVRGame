using System;

namespace Interaction
{
    public sealed class SocketReceiver : EventReceiver
    {
        EventSender cordSender;
        public override void InitialiseComponents()
        {

        }

        public override void Activate()
        {
            //cordSender.transform.parent;
        }
    }
}

namespace Interaction.CustomInspector
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(SocketReceiver)), Serializable]
    public class SocketReceiverEditor : EventReceiverEditor { }
#endif
}