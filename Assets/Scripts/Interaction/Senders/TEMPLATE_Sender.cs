using System;

namespace Interaction
{
    public sealed class TEMPLATE_Sender : EventSender
    {

    }
}

namespace Interaction.CustomInspector
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(TEMPLATE_Sender)), Serializable]
    public class TEMPLATE_SenderEditor : EventSenderEditor { }
#endif
}