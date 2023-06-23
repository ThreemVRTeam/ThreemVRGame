﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class CollisionEventSender : EventSender
    {

        /// <summary>
        /// Sends an Activate() message to all targets specified in the inspector.
        /// </summary>
        public override void ActivateTargets()
        {
            foreach (EventReceiver target in targets)
            {
                // null proof
                if (target != null)
                    target.Activate();
            }
        }
        private void OnTriggerEnter(Collider collision)
        {
            EventReceiver reciever = collision.gameObject.GetComponent<EventReceiver>();
            // null proof
            if (reciever == null)
            {
                return;
            }
            // check if it is one of the senders targets, activate if it is
            foreach(EventReceiver eR in targets)
            {
                if (eR == reciever)
                    reciever.Activate();
            }
        }
    }
}
