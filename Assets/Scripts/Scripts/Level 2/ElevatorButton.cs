using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : Interact
{
    public ElevatorInput elevatorInput;
    ElevatorScript elevatorScript;
    void Start()
    {
        elevatorScript = GameObject.Find("Elevator").GetComponent<ElevatorScript>();
        // elevatorInput = GameObject.Find("ELEVATOR UI").GetComponent<ElevatorInput>();
    }

    void Update()
    {
        
    }
    public override void OnFocus()
    {

    }
    public override void OnInteract()
    {
        Debug.Log("atLevel1 : " + elevatorInput.atLevel1);
        Debug.Log("Level 2 : " + elevatorInput.goingLevel2);
        Debug.Log("Level 3 : " + elevatorInput.goingLevel3);
        if(elevatorInput.goingLevel2 && elevatorInput.atLevel1)
        {
            elevatorScript.GotoLevel2();
            Debug.Log("Level 2 : " + elevatorInput.goingLevel2);
            elevatorInput.goingLevel3 = false;
            // elevatorInput.atLevel1 = false;
        }
        // else if(elevatorInput.goingLevel2 && !elevatorInput.atLevel1)
        // {
        //     elevatorScript.GotoLevel2();
        //     Debug.Log("Level 2 : " + elevatorInput.goingLevel2);
        //     // elevatorInput.goingLevel2 = false;
        //     elevatorInput.atLevel1 = true;
        // }
        if(elevatorInput.goingLevel3 && elevatorInput.atLevel1)
        {
            elevatorScript.GotoLevel3();
            Debug.Log("Level 3 : " + elevatorInput.goingLevel3);
            elevatorInput.goingLevel2 = false;
        }
    }

    public override void OnLoseFocus()
    {

    }
    
}
