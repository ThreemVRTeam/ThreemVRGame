using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Interaction
{
    public sealed class SoundPlayer : EventReceiver
    {
        [SerializeField] List<AudioSource> audioSources;

        public override void InitialiseComponents() => audioSources = GetComponents<AudioSource>().ToList();

        public override void Activate()
        {
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.Play();
            }
        }

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