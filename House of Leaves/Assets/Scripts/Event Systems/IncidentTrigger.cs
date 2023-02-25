using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncidentTrigger : MonoBehaviour
{
    // Tell the game manager that the player reached this trigger
    // From this point on, manager should handle randomizing seams every minute or two and
    // locking them in the hallways until their objective is done
    void OnTriggerEnter()
    {
        GameManager.SetHunt(true);
    }

    void OnTriggerExit()
    {
        this.enabled = false;
    }
}
