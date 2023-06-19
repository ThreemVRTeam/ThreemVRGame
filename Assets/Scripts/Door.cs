using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Transform handle = null;
    private Vector3 handleOriginalPos;

    // Start is called before the first frame update
    void Start()
    {
        handleOriginalPos = handle.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        handle.localPosition = handleOriginalPos;
    }
}
