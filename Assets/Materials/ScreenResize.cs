using UnityEngine;
using System.Collections;
public class ScreenResize : MonoBehaviour
{
    public Camera cam;
    public float width;
    public float height;

    void Start() { 

        cam = GetComponent<Camera>(); 
        width = cam.pixelWidth; 
        height = cam.pixelHeight; 
    }
    void Update() {
        if (width != cam.pixelWidth || height != cam.pixelHeight) 
        { 
            width = cam.pixelWidth; 
            height = cam.pixelHeight; 
            Screen.SetResolution((int)width, (int)height, true); } 
    }
}