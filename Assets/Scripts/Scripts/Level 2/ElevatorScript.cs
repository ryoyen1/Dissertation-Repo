using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public bool atLevel1 = true;
    public bool IsAtLevel2 = false;
    public bool IsAtLevel3 = false;
    private Animator animator;
    
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    public void GotoLevel2()
    {
        IsAtLevel2 = !IsAtLevel2;
        atLevel1 = !atLevel1;
        animator.SetBool("atLevel2", IsAtLevel2);
    }

    public void GotoLevel3()
    {
        IsAtLevel3 = !IsAtLevel3;
        atLevel1 = !atLevel1;
        animator.SetBool("atLevel3",IsAtLevel3);
    }

    public void GotoLevel1from2()
    {
        atLevel1 = !atLevel1;
        animator.SetBool("atLevel1", atLevel1);
    }
}
