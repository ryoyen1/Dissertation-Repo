using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Credits to Brackeys
//Youtube video : https://www.youtube.com/watch?v=CE9VOZivb3I

public class LevelLoaderEndScene : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            // movePlatform.GetComponent<Animator>().Play("NextLevelPlatform");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            LoadNextLevel();
        }
        //Do
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        animator.SetTrigger("start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
