using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Level3TermInput3 : MonoBehaviour
{
    FirstPerson firstPerson;
    public GameObject terminal;
    public GameObject floor;
    public TextAsset asset;
    public GameObject code;
    public GameObject transparentObj;
    public InputField inputField;
    public string codeUI;
    
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
                        Instantiate(floor,new Vector3(x,y,z), Quaternion.identity);
                        x += addX;
                        y += addY;
                        z += addZ;
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
}
