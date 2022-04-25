using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCard2 : Interact
{
    // public bool hasRedKey;
    private bool RedKeyObject = true;
    // public TextMeshProUGUI interactionText;
    // public int KeyCardCount;
    public GameObject UI;
    public GameObject RedKey2;
    KeypadScript KPS;
    KeyCard keycard;
    void Start() {
        keycard = GameObject.Find("RedKey").GetComponent<KeyCard>();
        // hasRedKey = false;
    }
    public override void OnFocus() {
        UI.SetActive(true);
        print ("hello, looking at me");
    }
    public override void OnInteract() {
        // keycard.hasRedKey = true;
        // KPS.canOpen = true;
        if (keycard.hasRedKey == true)
        {
            keycard.KeyCardCount += 1;
            Destroy(RedKey2);
            RedKeyObject = false;
            if(RedKeyObject == false)
            {
                UI.SetActive(false);
            }
            Debug.Log(keycard.KeyCardCount);
            // Debug.Log(hasRedKey);
            //Shows a message Obtained
        }
    }
    public override void OnLoseFocus() {
        UI.SetActive(false);
    }
}
