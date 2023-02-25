using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static List<Seam> seamList;
    static List<Seam> doorSeams;
    static List<Seam> hallSeams;
    static BoxCollider trapTrigger;
    static bool hunting = false;

    // Start is called before the first frame update
    void Start()
    {
        seamList = FindObjectsOfType<Seam>().ToList<Seam>();
        trapTrigger = GetComponentInChildren<BoxCollider>();

        doorSeams = new List<Seam>();
        hallSeams = new List<Seam>();

        foreach (Seam seam in seamList)
        {
            switch (seam.seamType)
            {
                case SeamType.Doorway:
                    doorSeams.Add(seam);
                    break;
                case SeamType.Hallway:
                    hallSeams.Add(seam);
                    break;
                default:
                    // do nothing
                    break;
            }
        }

        seamList.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (hunting)
        {

        }
    }

    public static void SetHunt(bool newValue)
    {
        // Idk if this would ever happen but just in case
        if (hunting == newValue)
            return;

        hunting = newValue;

        if (newValue == true)
        {
            // Start actually doing things
            
        }
    }
}
