using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam1 = new Camera();
    public Camera cam2 = new Camera();
    public void  Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
    }
    public void onCameraButtonClick()
    {
        cam1.enabled = !cam1.enabled;
        cam2.enabled = !cam2.enabled;
    }
}
