using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    public Image crosshair;

    // Collide exclusively with objects in layer 7
    int layerMask = 1 << 7;
    bool interacting = false;
    Door item;

    PlayerCamera playerCam;

    void Start()
    {
        playerCam = this.GetComponent<PlayerCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast 2.2f units in front of the camera on layer 7 (interactables)
        // Also make sure the player isn't already interacting with something first
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, 2.2f, layerMask) && !interacting)
        {
            crosshair.color = Color.yellow;

            // Left click to begin interacting
            // Could be opening/closing doors, picking up items, etc.
            if (Input.GetMouseButtonDown(0))
            {
                item = hit.transform.GetComponent<Door>();

                interacting = true;
                item.interacted = true;
                playerCam.interacting = true;
                crosshair.enabled = false;
            }
        }
        else
        {
            crosshair.color = Color.white;
        }

        // Tell the game that the player isn't interacting with anything anymore
        // Should *only* go off if the LMB is released AND user is interacting
        if (Input.GetMouseButtonUp(0) && interacting)
        {
            interacting = false;
            item.interacted = false;
            playerCam.interacting = false;
            crosshair.enabled = true;

            item = null;
        }
    }
}
