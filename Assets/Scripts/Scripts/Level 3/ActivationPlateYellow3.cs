using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationPlateYellow3 : MonoBehaviour
{
    public bool isActivated = false;
    public Material yellowMaterial;
    
    void Start() {
        yellowMaterial.DisableKeyword ("_EMISSION");
        
    }
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.name == "ActivationCubeYellow")
        {
            //Do
            
            isActivated = true;
            yellowMaterial.EnableKeyword ("_EMISSION");
           
        }
    }
    void OnCollisionExit(Collision other)
    {
            isActivated = false;
            yellowMaterial.DisableKeyword ("_EMISSION");
            
    }
}
