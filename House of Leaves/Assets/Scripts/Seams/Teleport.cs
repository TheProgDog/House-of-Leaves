using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public Transform outPortal;
    public Transform inPortal;
    public Transform player;

    bool triggered = false;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggered = true;
            print("HAAAAAAAAAAAAAAAAAAAAAAAAA");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggered = false;
        }
    }

    void Update()
    {
        if (triggered == true)
        {
            // Check the dot product between the player and the "up-plane" (i'm bad with words)
            // of the portal. If dot product is negative, player has entered from the front
            // so it's safe to do the thing
            Vector3 offset = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.right, offset);

            if (dotProduct < 0f)
            {
                Matrix4x4 matrix = outPortal.localToWorldMatrix * inPortal.worldToLocalMatrix * player.localToWorldMatrix;
                player.SetPositionAndRotation(matrix.GetPosition(), matrix.rotation);

                // Rays used to debug teleportation
                // Debug.DrawRay(inPortal.position, Vector3.up * 5, Color.blue, 20.0f);
                // Debug.DrawRay(outPortal.position, Vector3.up * 5, Color.green, 20.0f);
                // Debug.DrawRay(matrix.GetPosition(), Vector3.up * 5, Color.red, 20.0f);

                triggered = false;
            }
        }
    }
}
