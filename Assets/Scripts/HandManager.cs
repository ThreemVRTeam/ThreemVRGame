using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace HandControl
{

    public class HandManager : MonoBehaviour
    {
        public InputActionReference toggleHandModeControl;

        public UnityEvent handToggleOn, handToggleOff;

        // Start is called before the first frame update
        void Start()
        {
            toggleHandModeControl.action.performed += ToggleHandOn;
            toggleHandModeControl.action.canceled += ToggleHandOff;
        }
        public void ToggleHandOn(InputAction.CallbackContext context)
        {
            handToggleOn.Invoke();
        }
        public void ToggleHandOff(InputAction.CallbackContext context)
        {
            handToggleOff.Invoke();
        }
    }
}
