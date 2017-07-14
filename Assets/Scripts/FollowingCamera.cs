using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public GameObject targetObject;

    private float targetObjectX;
    private Vector3 newCameraPosition;
    private float distanceToTarget;

    // Use this for initialization
    void Start()
    {
        distanceToTarget = transform.position.x - targetObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        targetObjectX = targetObject.transform.position.x;

        newCameraPosition = transform.position;
        newCameraPosition.x = targetObjectX + distanceToTarget;
        transform.position = newCameraPosition;
    }
}
