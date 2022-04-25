using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2TrapScript : Interact
{
    Level2Trap level2Trap;
    Level2SlideUp level2SlideUp;
    public GameObject terminal;
    Level2TrapDoorTerminal level2TrapDoorTerminal;
    void Start()
    {
        level2Trap = GameObject.Find("TrapDoorLeft").GetComponent<Level2Trap>();
        level2SlideUp = GameObject.Find("UnderPlatform").GetComponent<Level2SlideUp>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnFocus()
    {

    }
    public override void OnInteract()
    {
        terminal.SetActive(true);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    public override void OnLoseFocus()
    {

    }
}
