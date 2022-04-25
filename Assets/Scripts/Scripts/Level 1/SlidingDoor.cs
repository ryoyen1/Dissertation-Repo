using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour {
    private Animator animator;
    public bool isOpen = false;
    void Start(){
         animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        isOpen = !isOpen;
        animator.SetBool("opening", isOpen);
        Debug.Log("Test");
    }
}

    

