using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abstract to make interact class inheritable
public abstract class Interact : MonoBehaviour
{  
    //All object in layer 6 is an Interactable object
    public virtual void Awake() {
        gameObject.layer = 6;
    }
    public abstract void OnInteract();
    public abstract void OnFocus();
    public abstract void OnLoseFocus();
    // public abstract string GetDescription();
}
