using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] GameObject Flashlight;
    private bool Active = false;
    // Start is called before the first frame update
    void Start()
    {
        Flashlight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(Active == false)
            {
                Flashlight.gameObject.SetActive(true);
                Active = true;
            }
            else
            {
                Flashlight.gameObject.SetActive(false);
                Active = false;
            }

        }
    }
}
