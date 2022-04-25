using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUILogic : MonoBehaviour
{
    public string popUpText;
    
    void Start()
    {
        DialogUIPopUp popUp = GameObject.FindGameObjectWithTag("Player").GetComponent<DialogUIPopUp>();
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
        DialogUIPopUp popUp = GameObject.FindGameObjectWithTag("Player").GetComponent<DialogUIPopUp>();
        popUp.PopUp(popUpText);
        
        yield return new WaitForSeconds(2);

        popUp.ClosePopUp(popUpText);

    }
}
