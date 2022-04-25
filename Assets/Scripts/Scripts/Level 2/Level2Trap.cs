using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Trap : MonoBehaviour
{
    private Animator animator;
    public bool isOpen = false;
    void Start(){
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void OpenTrapDoorLeft()
    {
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
        Debug.Log("Test");
    }
    
}
