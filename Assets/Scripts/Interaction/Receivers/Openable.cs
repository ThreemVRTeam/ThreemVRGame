using System;
using UnityEngine;

namespace Interaction
{
    [ExecuteInEditMode] public sealed class Openable : EventReceiver
    {
        public Transform doorToMove;

        private Vector3 closedPosition;
        private Quaternion closedRotation;
        private Vector3 closedScale;

        private Vector3 openPosition;
        private Quaternion openRotation;
        private Vector3 openScale;

        private float startTime;
        private float finishTime;
        [SerializeField, Range(0.1f,10f)] float duration;
        private bool opening = false;

        [Space()]

        [SerializeField] Vector3 slideAmount;
        [SerializeField] Vector3 rotateAmount;
        [SerializeField] Vector3 scaleAmount;

        float ProgressPercent()
        {
            return (Time.time - startTime) / duration;
        }

        public override void InitialiseComponents()
        {
            //doorToMove = gameObject.transform;

            closedPosition = doorToMove.position;
            closedRotation = doorToMove.rotation;
            closedScale = doorToMove.localScale;

            openPosition = closedPosition + slideAmount;
            openRotation = closedRotation * Quaternion.Euler(rotateAmount);
            openScale = closedScale + scaleAmount;
        }

        public override void Activate()
        {
            startTime = Time.time;
            finishTime = Time.time + duration;
            opening = true;
        }

        private void Update()
        {
            if (!opening) return;

            bool finished = Time.time >= finishTime;

            if (!finished)
            {
                doorToMove.position = closedPosition + slideAmount * ProgressPercent();
                doorToMove.rotation = closedRotation * Quaternion.Euler(rotateAmount * ProgressPercent());
                doorToMove.localScale = closedScale + scaleAmount * ProgressPercent();
            }
            else
            {
                doorToMove.SetPositionAndRotation(openPosition, openRotation);
                doorToMove.localScale = openScale;
                opening = false;
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