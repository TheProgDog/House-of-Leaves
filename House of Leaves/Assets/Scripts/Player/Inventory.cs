using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int space = 8;
    Key heldKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddItem(Pickup item)
    {
        // Check to see if key first, since this will likely be the primary type of collectible
        if (item.GetType() == typeof(Key))
        {
            if (item.tier >= heldKey.tier)
            {
                // New key's tier exceeds the current tier, pick up
            }
        }
    }
}
