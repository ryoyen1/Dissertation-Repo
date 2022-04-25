using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTriggerNextLevel : MonoBehaviour
{
    public GameObject movePlatform;
    LevelLoader levelLoader;

    void Start()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            movePlatform.GetComponent<Animator>().Play("NextLevelPlatform");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            levelLoader.LoadNextLevel();
        }
    }
}
