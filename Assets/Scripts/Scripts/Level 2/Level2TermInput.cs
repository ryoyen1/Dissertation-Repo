using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Level2TermInput : MonoBehaviour
{
    FirstPerson firstPerson;
    public GameObject terminal;
    public GameObject floor;
    public TextAsset asset;
    public GameObject code;
    public GameObject transparentObj;
    public InputField inputField;
    public string codeUI;
    public TMPro.TMP_Text lineNumbersUI;
    public bool isFound = false;
    // public 
    void Start() {
        firstPerson = GameObject.Find("Player").GetComponent<FirstPerson>();
        firstPerson.CanMove = false;
        terminal.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       
    }
    void Update() {
        SetLineNumbers();
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
            string[] textLinesTest = {"whatsup", "hello"};
            float z = 8.4f;
            for (int i = 0; i < textLines.Length; i++ ) 
            {
                Debug.Log(textLines[i]);
                if(codeUI == textLines[i])
                {
                    // transparentObj.SetActive(false);
                    print("WORKSSS");
                    Debug.Log("congrats it works");
                    for(int j = 0; j < i+1; j++)
                    {
                        Debug.Log(i);
                        Instantiate(floor,new Vector3(-18f,12.75f,z), Quaternion.identity);
                        z += 3f;
                        Debug.Log("Z axis : " + z);
                    }
                    
                }

            }
    
            Debug.Log("CodeUI : " + codeUI);
       
            for (int i = 0; i < textLinesTest.Length; i++ ) 
            {
                if(codeUI == textLinesTest[i])
                {
                    print("WORKSSS for test");
                    Debug.Log("congrats it works");
                }
            }
    }

    void SetLineNumbers () {
        string numbers = "";

        int numLines = codeUI.Split ('\n').Length;
        for (int i = 0; i < numLines; i++) {
            numbers += (i + 1) + "\n";
        }

        lineNumbersUI.text = numbers;
    }
}
