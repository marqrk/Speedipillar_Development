using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ToggleInitiatorScript : MonoBehaviour
{
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Toggle>().isOn = cube.GetComponent<JsonHandlerScript>().playerSettings.StickControls;
    }
}
