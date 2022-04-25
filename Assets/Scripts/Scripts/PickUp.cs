using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PickUp : MonoBehaviour {

    public Transform destination;
    void OnMouseDown() 
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().isKinematic = true;
        this.transform.position = destination.position;
        this.transform.parent = GameObject.Find("Destination").transform;

    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = false;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
