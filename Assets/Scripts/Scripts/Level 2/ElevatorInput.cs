using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ElevatorInput : MonoBehaviour
{
    FirstPerson firstPerson;
    Animator animator;
    Level2Elevator level2elevator;
    ElevatorScript elevatorScript;
    public GameObject terminal;
    public GameObject floor;
    public TextAsset asset;
    public GameObject code;
    public InputField inputField;
    public string codeUI;
    public bool atLevel1;
    public bool goingLevel2;
    public bool goingLevel3;
    void Start() {
        animator = GetComponent<Animator>();
        elevatorScript = GameObject.Find("Elevator").GetComponent<ElevatorScript>();
        firstPerson = GameObject.Find("Player").GetComponent<FirstPerson>();
        firstPerson.CanMove = false;
        terminal.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        atLevel1 = true;
        goingLevel2 = false;
        goingLevel3 = false;
        Debug.Log(goingLevel2);
        
    }
    void Update() {
       
        if (Input.GetKeyDown (KeyCode.C) && (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.LeftCommand)))
        {
            RemoveSpace();
            DO();
            firstPerson.CanMove = true;
            
            terminal.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Input.GetKeyDown (KeyCode.R))
        {
            Restart();
        }
    }
    void Restart()
    {
        
    }
    void RemoveSpace()
    {
        codeUI = codeUI.Replace("\n", "");
        inputField.text = inputField.text.Replace("\n", "").Replace("\r","");
    }
    void DO()
    {
            codeUI = code.GetComponent<Text>().text;
            string textAsset = asset.text;
            // string newtext = textAsset.Replace("\n","");
            string[] textLines = textAsset.Split(',');
            string[] textLinesTest = {"elevator.level(1)", "elevator.level(2)","elevator.level(3)"};
            float z = 1f;
            for (int i = 0; i < textLinesTest.Length; i++ ) 
            {
                Debug.Log(textLines[i]);
                if(codeUI == textLinesTest[1])
                {
                    print("GO TO LEVEL2 FROM 1");
                    Debug.Log("congrats it works");
                    goingLevel2 = true;
                    
                    goingLevel3 =false;
                    
                }
                else if(codeUI == textLinesTest[2])
                {
                    print("GO TO LEVEL3 FROM 1");
                    Debug.Log("congrats it works");
                    goingLevel3 = true;
                    
                    
                    goingLevel2 = false;
                    
                }
                else if(codeUI == textLinesTest[0] && goingLevel2)
                {
                    goingLevel2 = false;
                    elevatorScript.GotoLevel2();
                }
                else if(codeUI == textLinesTest[0] && goingLevel3)
                {
                    goingLevel3 = false;
                    elevatorScript.GotoLevel3();
                }
            }
        Debug.Log("CodeUI : " + codeUI);
    }
}
