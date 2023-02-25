using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Door : MonoBehaviour
{
    public bool interacted = false;
    public bool locked = false;
    public int tier = -1;

    public HUD hud;

    //Rigidbody rb;

    void start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (interacted && locked)
        {
            hud.ChangeMessage("This door is locked...");
            print($"Door script: This door is locked...");
        }
        else if (interacted)
        {
            float mouseX = Input.GetAxis("Mouse X") * 125f * Time.deltaTime;

            transform.Rotate(Vector3.down * mouseX);
            //rb.AddTorque(Vector3.down * mouseX);

            //print("Door mouseX: " + mouseX);
        }
    }

    void Unlock(Key heldKey)
    {
        if (heldKey.tier >= tier)
            locked = false;
    }
}
