using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PortalCam : MonoBehaviour
{
    public Transform inPortal;
    public Transform outPortal;
    public Transform playerCamera;

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void OnPreCull()
    {
        // Matrix multiplication stuff
        Matrix4x4 matrix = outPortal.localToWorldMatrix * inPortal.worldToLocalMatrix * playerCamera.localToWorldMatrix;
        transform.SetPositionAndRotation(matrix.GetPosition(), matrix.rotation);

        // Now we check the distance between the camera and target
        // to adjust the near clipping plane
        // float clippingDistance = Vector3.Distance(matrix.GetPosition(), outPortal.position);
        // cam.nearClipPlane = clippingDistance;
    }
}
