using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Level3TermInputLast : MonoBehaviour
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
    [SerializeField] public float x = 0f;
    [SerializeField] public float y = 0f;
    [SerializeField] public float z = 0f;
    [SerializeField] public float addX = 0f;
    [SerializeField] public float addY = 0f;
    [SerializeField] public float addZ = 0f;
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
            // string newtext = textAsset.Replace("\n","");
            string[] textLines = textAsset.Split(',');
            string[] textLinesTest = {"whatsup", "hello"};
            for (int i = 0; i < textLines.Length; i++ ) 
            {
                Debug.Log(textLines[i]);
                if(codeUI == textLines[i])
                {
                    // transparentObj.SetActive(false);
                    print("WORKSSS");
                    Debug.Log("congrats it works");
                    for(int j = 1; j <= 4+1; j++)
                    {
                        Debug.Log(i);
                        // for (int k = 1; k <= j;k++)
                        // {
                            Instantiate(floor,new Vector3(x,y,z), Quaternion.Euler(-90,0,0));
                            Instantiate(floor,new Vector3(x+1.5f,y,z), Quaternion.Euler(-90,0,0));
                            Instantiate(floor,new Vector3(x+3f,y,z), Quaternion.Euler(-90,0,0));
                            Instantiate(floor,new Vector3(x+4.5f,y,z), Quaternion.Euler(-90,0,0));
                            x += addX;
                            y += addY;
                            z += addZ;
                        // }
                        Debug.Log("Z axis : " + z);
                    }
                    // break;
                }

            }
            // Debug.Log("SOLUTION : " + textLines[2]);
            // Debug.Log(codeUI + " == " + textLines[2]);
            Debug.Log("CodeUI : " + codeUI);
        // Debug.Log("Text : " + text);
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
