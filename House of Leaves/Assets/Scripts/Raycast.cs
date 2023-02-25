using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Color rayColor1;
    public Color rayColor2;
    public Color rayColor3;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.blue, 1.0f);
        Debug.DrawRay(transform.position, transform.up, Color.green, 1.0f);
        Debug.DrawRay(transform.position, transform.right, Color.red, 1.0f);
    }
}
