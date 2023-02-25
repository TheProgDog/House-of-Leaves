using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SeamType
{
    Doorway,
    Hallway,
    Staircase
}

public class Seam : MonoBehaviour
{
    public Seam targetSeam;
    public SeamType seamType;
    public Shader seamShader;

    GameObject player;
    Camera playerCamera;

    // Objects belonging to the entrance
    GameObject renderChild;
    GameObject renderPlane;
    GameObject entryPoint;
    GameObject renderBackwards;
    Teleport teleportScript;

    // Objects belonging to the exit
    GameObject exitChild;
    Camera seamCamera;
    PortalCam seamCameraScript;
    GameObject exitBackwards;

    // Start is called before the first frame update
    void Start()
    {
        // Return and don't do anything if there is no target
        if (!targetSeam)
        {
            print($"No target designated for {transform.name}!");
            return;
        }

        // Player references
        player = GameObject.FindGameObjectWithTag("Player");
        playerCamera = player.transform.GetChild(0).GetComponent<Camera>();

        // Fetch the "render/trigger" child of this object, plus its own children
        renderChild = transform.GetChild(1).gameObject;
        renderPlane = renderChild.transform.GetChild(0).gameObject;
        entryPoint = renderChild.transform.GetChild(1).gameObject;
        renderBackwards = renderChild.transform.GetChild(2).gameObject;
        teleportScript = entryPoint.GetComponent<Teleport>();

        // Connect the two seams, make sure they
        // reference each other wherever needed
        // TODO: Restructure the function so that
        // anything dealing with the current object's children
        // is done outside, function only collects target's children
        ConnectSeams();

        // After the above is set up, initialize the texture
        InitializeTextures();
    }

    // Initialize the texture that this seam will be using
    void InitializeTextures()
    {
        if (seamCamera.targetTexture != null)
        {
            seamCamera.targetTexture.Release();
        }

        RenderTexture seamTexture = new RenderTexture(Screen.width, Screen.height, 64);
        seamCamera.targetTexture = seamTexture;

        // Fetch the material used by the Render Plane and apply the render texture to it
        Material targetMaterial = renderPlane.GetComponent<MeshRenderer>().material;
        targetMaterial.mainTexture = seamTexture;
        targetMaterial.shader = seamShader;
    }

    public void ConnectSeams()
    {
        // Fetch the "exit point" child in the destination
        exitChild = targetSeam.transform.GetChild(0).gameObject;

        // Fetching children of the "exit point" object
        seamCamera = exitChild.transform.GetChild(0).GetComponent<Camera>();
        seamCameraScript = seamCamera.GetComponent<PortalCam>();
        exitBackwards = exitChild.transform.GetChild(1).gameObject;

        // Initialize references for camera script
        seamCameraScript.inPortal = renderBackwards.transform;
        seamCameraScript.outPortal = exitChild.transform;
        seamCameraScript.playerCamera = playerCamera.transform;

        // Initializing references for teleport script
        teleportScript.inPortal = renderBackwards.transform;
        teleportScript.outPortal = exitChild.transform;
        teleportScript.player = player.transform;
    }

    // Is this kind of garbage collection necessary?? We'll see
    public void RemoveSeams()
    {
        exitChild = null;
        
        seamCamera = null;
        seamCameraScript = null;
        exitBackwards = null;
        seamCameraScript.inPortal = null;
        seamCameraScript.outPortal = null;
    }
}
