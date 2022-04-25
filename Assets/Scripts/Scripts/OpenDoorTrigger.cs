using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour
{
    public GameObject movePlatform;
    private Animator animator;
    public bool isOpen = false;
    SlidingDoor slidingDoor;

    void Start()
    {
        slidingDoor = GameObject.Find("LP_Bay_Door_snaps2").GetComponent<SlidingDoor>();
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            slidingDoor.OpenDoor();
        }
    }
}
