using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private string controlsHint = "Controls: WASD = move, SPACE = Jump, SHIFT = Run, MOUSE: Control Camera";
    private bool playerWantsToExit = false;
    
    
    void Start()
    {
        PlayerPrefs.SetInt("Completed", 0);
        PlayerPrefs.Save();
        UIManager.instance.DisplayTimedHint(controlsHint, 20f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
        StartCoroutine(UpdateCamerasWithDelay());
        
    }

    IEnumerator UpdateCamerasWithDelay()
    {
        yield return new WaitForSeconds(0.01f);
        UIManager.instance.RelinkSignCamera();
        UIManager.instance.ToggleSignCamera(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!playerWantsToExit)
            {
                playerWantsToExit = true;
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
