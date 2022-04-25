using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Level2Terminal : Interact
{
    public GameObject terminal;
    FirstPerson firstPerson;
    private bool onTerminal = false;
    public override void OnFocus() {
        firstPerson = GameObject.Find("Player").GetComponent<FirstPerson>();
        print ("hello, looking at me");
    }
    public override void OnInteract() {
        terminal.SetActive(true);
        onTerminal = true;
        firstPerson.CanMove = false;
        if(onTerminal == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public override void OnLoseFocus() {
        
    }
}
