using System;
using System.Collections;
using UnityEngine;

namespace Interaction
{
    public sealed class Openable : EventReceiver
    {
        private Transform transformReference;

        private Vector3 closedPosition;
        private Quaternion closedRotation;
        private Vector3 closedScale;

        private Vector3 openPosition;
        private Quaternion openRotation;
        private Vector3 openScale;

        private float startTime;
        private float finishTime;
        [SerializeField] float duration;
        private bool opening = false;

        [SerializeField] float slideAmount;
        [SerializeField] float rotateAmount;
        [SerializeField] float scaleAmount;

        float ProgressPercent()
        {
            return (Time.time - startTime) / duration;
        }

        public override void InitialiseComponents()
        {
            transformReference = gameObject.transform;
        }

        public override void Activate()
        {
            startTime = Time.time;
            finishTime = Time.time + duration;
            opening = true;
        }

        private void Update()
        {
            if (opening)
            {
                if (Time.time >= finishTime)
                {
                    transformReference.SetPositionAndRotation(openPosition, openRotation);
                    transformReference.localScale = openScale;
                    opening = false;
                }
                else
                {
                    //opening lerp
                }
            }
        }
    }
}

namespace Interaction.CustomInspector
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(Openable)), Serializable]
    public class OpenableEditor : EventReceiverEditor { }
#endif
}