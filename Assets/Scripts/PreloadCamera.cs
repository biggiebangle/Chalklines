using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PreloadCamera : MonoBehaviour
{

    private WebCamTexture Cam;

    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("There are no cameras.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
