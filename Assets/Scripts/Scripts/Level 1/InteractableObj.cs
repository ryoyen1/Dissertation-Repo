using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : Interact
{
    public GameObject terminal;
    public override void OnFocus() {
        print ("hello, looking at me");
    }
    public override void OnInteract() {
        terminal.SetActive(true);
    }
    public override void OnLoseFocus() {
        
    }
}
