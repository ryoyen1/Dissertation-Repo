using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationPlate : MonoBehaviour
{
    public bool isActivated = false;
    public Material redMaterial;
    public Light myLight;
    void Start() {
        redMaterial.DisableKeyword ("_EMISSION");
        myLight = myLight.GetComponent<Light>();
        myLight.enabled = false;
    }
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.name == "ActivationCube")
        {
            //Do
            // Destroy(other.gameObject);
            isActivated = true;
            redMaterial.EnableKeyword ("_EMISSION");
            myLight.enabled = !myLight.enabled;
        }
    }
    void OnCollisionExit(Collision other)
    {
            isActivated = false;
            redMaterial.DisableKeyword ("_EMISSION");
            myLight.enabled = !myLight.enabled;
    }
}
