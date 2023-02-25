using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public GameObject targetTrigger;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            targetTrigger.SetActive(false);
            print("Disabling trigger!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            targetTrigger.SetActive(true);
            print("Enabling trigger!");
        }
    }
}
