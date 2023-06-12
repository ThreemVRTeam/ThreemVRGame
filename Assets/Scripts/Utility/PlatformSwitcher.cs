using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// turns objects on or off based on platform - are we running in editor or on device?
public class PlatformSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR

#else
        gameObject.SetActive(false);
#endif
    }

}
