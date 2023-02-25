using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    static TextMeshProUGUI hudText;

    // Start is called before the first frame update
    void Start()
    {
        hudText = transform.GetComponentInChildren<TextMeshProUGUI>();
        print($"Hud text: {hudText.name}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ChangeMessage(string msg)
    {
        print($"HUD script: {msg}");
        hudText.text = msg;

        yield return new WaitForSeconds(3f);

        hudText.text = "";
    }
}
