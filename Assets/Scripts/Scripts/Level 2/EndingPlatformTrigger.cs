using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPlatformTrigger : MonoBehaviour
{
    public GameObject movePlatform;

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            movePlatform.GetComponent<Animator>().Play("EndingAnimation");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
