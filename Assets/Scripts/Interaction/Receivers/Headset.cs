using System;
using UnityEngine;
using Level;

namespace Interaction
{
    public sealed class Headset : EventReceiver
    {
        const string playerTag = "Player";
        [SerializeField] ProgressionManager progressionManager;

        private bool active;
        [SerializeField] bool startActive = true;

        public override void InitialiseComponents()
        {
            if (progressionManager is null)
                GameObject.Find("GameManager").GetComponent<ProgressionManager>();

            active = startActive;
        }

        public override void Activate() => active = true;

        private void OnTriggerEnter(Collider other)
        {
            if (!active) return;

            if (other.CompareTag(playerTag))
            {
                progressionManager.ProgressGame();

                Destroy(gameObject);
            }
        }
    }
}

namespace Interaction.CustomInspector
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(Headset)), Serializable]
    public class HeadsetEditor : EventReceiverEditor { }
#endif
}