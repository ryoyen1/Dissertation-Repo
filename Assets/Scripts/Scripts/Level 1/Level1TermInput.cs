using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Level1TermInput : MonoBehaviour
{
    FirstPerson firstPerson;
    public string popUpText;
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
        UIPopUp popUp = GameObject.FindGameObjectWithTag("Player").GetComponent<UIPopUp>();
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
            float z = 1f;
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
                        Instantiate(floor,new Vector3(-16.5f,12f,z), Quaternion.identity);
                        z += 3f;
                        Debug.Log("Z axis : " + z);
                    }
                    // break;
                }
                else
                {
                    StartCoroutine(UITimeout());
                }

            }
            Debug.Log("CodeUI : " + codeUI);
    }
    private IEnumerator UITimeout()
    {
        UIPopUp popUp = GameObject.FindGameObjectWithTag("Player").GetComponent<UIPopUp>();
        popUp.PopUp(popUpText);
        
        yield return new WaitForSeconds(2);

        popUp.ClosePopUp(popUpText);

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
