using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationPlateYellow3 : MonoBehaviour
{
    public bool isActivated = false;
    public Material yellowMaterial;
    // public Light myLight;
    void Start() {
        yellowMaterial.DisableKeyword ("_EMISSION");
        // myLight = myLight.GetComponent<Light>();
        // myLight.enabled = false;
    }
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.name == "ActivationCubeYellow")
        {
            //Do
            // Destroy(other.gameObject);
            isActivated = true;
            yellowMaterial.EnableKeyword ("_EMISSION");
            // myLight.enabled = !myLight.enabled;
        }
    }
    void OnCollisionExit(Collision other)
    {
            isActivated = false;
            yellowMaterial.DisableKeyword ("_EMISSION");
            // myLight.enabled = !myLight.enabled;
    }
}
