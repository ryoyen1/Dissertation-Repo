using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadScript2 : Interact
{
    private Animator animator;
    KeyCard keycard;
    SlidingDoor slidingDoor;
    SlidingDoor2 slidingDoor2;
    DialogUIPopUp popUp;
    DialogUILogic dialogUILogic;
    public string popUpText;
    public bool canOpen = false;
    public bool isInteractable = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        keycard = GameObject.Find("RedKey").GetComponent<KeyCard>();
        slidingDoor = GameObject.Find("LP_Bay_Door_snaps").GetComponent<SlidingDoor>();
       
    }
    public override void OnFocus()
    {

    }
    public override void OnInteract()
    {
        
        if(keycard.hasRedKey)
        {
            canOpen = true;
            Debug.Log("Red Key : " + keycard.hasRedKey);
            Debug.Log("Red Key Count : " + keycard.KeyCardCount);
            if(canOpen && isInteractable)
            {
               
                
            }
            if(keycard.KeyCardCount == 2)
            {
                slidingDoor.OpenDoor();
            }
            else if (keycard.KeyCardCount == 1)
            {
                StartCoroutine(UITimeout());
            }
        }
        else
        {
           
            print("dont have key");
        }
    }

    public override void OnLoseFocus()
    {

    }

    private IEnumerator UITimeout()
    {
        DialogUIPopUp popUp = GameObject.FindGameObjectWithTag("Player").GetComponent<DialogUIPopUp>();
        popUp.PopUp(popUpText);
        
        yield return new WaitForSeconds(2);

        popUp.ClosePopUp(popUpText);

    }
}
