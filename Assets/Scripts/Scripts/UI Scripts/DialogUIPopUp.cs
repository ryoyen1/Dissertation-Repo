using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogUIPopUp : MonoBehaviour
{
    public GameObject UIBox;
    public Animator animator;
    public TMP_Text UIText;

    public void PopUp(string text)
    {
        UIBox.SetActive(true);
        UIText.text = text;
        animator.SetTrigger("popup");
    }

    public void ClosePopUp(string text)
    {
        UIText.text = text;
        animator.SetTrigger("closepop");
        // UIBox.SetActive(false);
    }
}
