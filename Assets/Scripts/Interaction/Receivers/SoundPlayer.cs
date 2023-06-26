using System;
using UnityEngine;

namespace Interaction
{
    public sealed class SoundPlayer : EventReceiver
    {
        [SerializeField] AudioSource audioSource;

        public override void InitialiseComponents() => audioSource = GetComponent<AudioSource>();

        public override void Activate() => audioSource.Play();
    }
}

namespace Interaction.CustomInspector
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(SoundPlayer)), Serializable]
    public class SoundPlayerEditor : EventReceiverEditor { }
#endif
}