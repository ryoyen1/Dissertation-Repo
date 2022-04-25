using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level1TermInput2 : MonoBehaviour
{
    FirstPerson firstPerson;
    public string popUpText;
    public GameObject terminal;
    public GameObject floor;
    public TextAsset asset;
    public GameObject code;
    public InputField inputField;
    public string codeUI;
    // public TMPro.TMP_Text lineNumbersUI;
    public bool isFound;
    // public 
    void Start() {
        firstPerson = GameObject.Find("Player").GetComponent<FirstPerson>();
        UIPopUp popUp = GameObject.FindGameObjectWithTag("Player").GetComponent<UIPopUp>();
        firstPerson.CanMove = false;
        terminal.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isFound = false;
       
    }
    void Update() {
        // SetLineNumbers();
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
        UIPopUp popUp = GameObject.FindGameObjectWithTag("Player").GetComponent<UIPopUp>();
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
                isFound = true;
                for(int j = 0; j < i+1; j++)
                {
                    Debug.Log(i);
                    Instantiate(floor,new Vector3(7.5f,16.5f,z), Quaternion.identity);
                    z += 3f;
                    Debug.Log("Z axis : " + z);
                    popUp.ClosePopUp(popUpText);
                }
            break;
            }if(codeUI != textLines[i])
            {
                isFound =false;
            }
        }
        if(!isFound)
        {
            StartCoroutine(UITimeout());
           
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

    
}

