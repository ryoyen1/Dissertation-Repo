using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Credits to Brackeys
//Youtube video : https://www.youtube.com/watch?v=CE9VOZivb3I

public class LevelLoader : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        animator.SetTrigger("start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
