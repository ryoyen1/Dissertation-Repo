using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2SlideUp : MonoBehaviour
{
    private Animator animator;
    public bool slideUp = false;
    void Start(){
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void SlideUpPlatform()
    {
        slideUp = !slideUp;
        animator.SetBool("SlideUp", slideUp);
        Debug.Log("Test");
    }
}
