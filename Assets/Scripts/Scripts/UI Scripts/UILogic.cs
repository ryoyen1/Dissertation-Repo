using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogic : MonoBehaviour
{
    public string popUpText;
    
    void Start()
    {
        UIPopUp popUp = GameObject.FindGameObjectWithTag("Player").GetComponent<UIPopUp>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            StartCoroutine(UITimeout());
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private IEnumerator UITimeout()
    {
        UIPopUp popUp = GameObject.FindGameObjectWithTag("Player").GetComponent<UIPopUp>();
        popUp.PopUp(popUpText);
        
        yield return new WaitForSeconds(2);

        popUp.ClosePopUp(popUpText);

    }
}
