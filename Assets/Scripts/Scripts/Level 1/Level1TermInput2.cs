using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level1TermInput2 : MonoBehaviour
{
    FirstPerson firstPerson;
    public GameObject terminal;
    public GameObject floor;
    public TextAsset asset;
    public GameObject code;
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
        // terminal.SetActive(false);
    }
    void Update() {
        SetLineNumbers();
        if (Input.GetKeyDown (KeyCode.C) && (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.LeftCommand)))
        {
            RemoveSpace();
            DO();
            firstPerson.CanMove = true;
            // GetCodeText();
            // Debug.Log(codeUI);
            terminal.SetActive(false);
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
            float z = 7.25f;
            for (int i = 0; i < textLines.Length; i++ ) 
            {
                Debug.Log(textLines[i]);
                if(codeUI == textLines[i])
                {
                    print("WORKSSS");
                    Debug.Log("congrats it works");
                    for(int j = 0; j < i+1; j++)
                    {
                        Debug.Log(i);
                        Instantiate(floor,new Vector3(7.5f,16.5f,z), Quaternion.identity);
                        z += 3f;
                        Debug.Log("Z axis : " + z);
                    }
                }
            }
            Debug.Log("CodeUI : " + codeUI);
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

