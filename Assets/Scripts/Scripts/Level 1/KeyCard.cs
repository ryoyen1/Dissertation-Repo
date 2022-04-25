using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCard : Interact
{
    public bool hasRedKey;
    private bool RedKeyObject = true;
    public int KeyCardCount;
    public GameObject UI;
    public GameObject RedKey;
    KeypadScript KPS;
    void Start() {
        hasRedKey = false;
    }
    public override void OnFocus() {
        UI.SetActive(true);
        print ("hello, looking at me");
    }
    public override void OnInteract() {
        hasRedKey = true;
        if (hasRedKey == true)
        {
            KeyCardCount += 1;
            Destroy(RedKey);
            RedKeyObject = false;
            if(RedKeyObject == false)
            {
                UI.SetActive(false);
            }
            Debug.Log(KeyCardCount);
            Debug.Log(hasRedKey);
            //Shows a message Obtained
        }
    }
    public override void OnLoseFocus() {
        UI.SetActive(false);
    }
}
