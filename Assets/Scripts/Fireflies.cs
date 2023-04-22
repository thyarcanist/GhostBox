using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireflies : MonoBehaviour

{
    public Transform itself;
    public Transform other;

    public float travelSpeed = 1f;
    public float maxMagnitudeDelta = 1;
    public float speed;
    public float rotationOffset;

    private void Start()
    {
        Mathf.LerpAngle(itself.position.x, other.position.x, 2.5f);     
    }

    // Update is called once per frame

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.z = 95.8f;
        transform.position = pos;
    }

    private void LateUpdate()
    {
        Mathf.Lerp(itself.position.x, other.position.x, travelSpeed);
    }

}
