using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedObject : MonoBehaviour
{
    Transform someBone;

    void Start()
    {
        someBone = GameObject.Find("ObjectHand").transform;
        transform.parent = someBone;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = someBone.localRotation;
        transform.localScale = someBone.localScale;
    }
}