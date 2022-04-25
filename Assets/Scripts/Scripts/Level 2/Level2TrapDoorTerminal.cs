using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Level2TrapDoorTerminal : MonoBehaviour
{
    FirstPerson firstPerson;
    ActivationPlate activationPlate;
    Level2Trap level2Trap;
    Level2SlideUp level2SlideUp;

    public GameObject terminal;
    public GameObject floor;
    public TextAsset asset;
    public GameObject code;
    public GameObject transparentObj;
    public InputField inputField;
    public string codeUI;
    
    public bool isFound = false;
    // public 
    void Start() {
        firstPerson = GameObject.Find("Player").GetComponent<FirstPerson>();
        activationPlate = GameObject.Find("RedPlate").GetComponent<ActivationPlate>();
        level2Trap = GameObject.Find("TrapDoorLeft").GetComponent<Level2Trap>();
        level2SlideUp = GameObject.Find("UnderPlatform").GetComponent<Level2SlideUp>();
        firstPerson.CanMove = false;
        terminal.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        inputField.text = "if(greenlight && redlight && yellowlight)";
       
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
            
            string[] textLines = textAsset.Split(',');
            string[] textLinesTest = {"test1", "test2"};
            float x = -12.25f;
            for (int i = 0; i < textLines.Length; i++ ) 
            {
                Debug.Log(textLines[i]);
                if(codeUI == textLines[i] && activationPlate.isActivated)
                {
                    print("Activate");
                    level2Trap.OpenTrapDoorLeft();
                    level2SlideUp.SlideUpPlatform();
                }else if(codeUI == textLines[i] && !activationPlate.isActivated)
                {
                    print("Activate the plate to continue");
                }

            }
            Debug.Log("CodeUI : " + codeUI);
    }

    
}
