using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : Ghosts
{
    // inherits from Ghosts but behaves a little differently.
    public Transform target;
    [SerializeField] public float smoothTime = 0.3F;
    [SerializeField] private Vector3 velocity = Vector3.zero;
    [SerializeField] private GameObject Box;
    [SerializeField] bool bIsAtPosition = false;

    private void Awake()
    {
        Box = GameObject.FindGameObjectWithTag("Box");
    }
    private void Update()
    {

        //// Define a target position above and behind the target transform
        //Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));

        //if (transform.position != targetPosition)
        //{
        //    // Smoothly move the camera towards that target position
        //    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //    transform.Rotate(1, 0, 0);
        //}
    }
}