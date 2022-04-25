using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MenuCameraBehaviour : MonoBehaviour
{
    public CinemachineVirtualCamera CinemaCamera;
    void Start()
    {
        CinemaCamera.Priority++;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    
    public void UpdateCamera(CinemachineVirtualCamera target)
    {
        CinemaCamera.Priority--;
        CinemaCamera = target;
        CinemaCamera.Priority++;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
