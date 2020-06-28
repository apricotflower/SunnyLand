using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public GameObject resumeMenu;
    public Button pause;
    
    public void PressPause()
    {
        resumeMenu.SetActive(true);
        pause.interactable = false;
        Time.timeScale = 0f;

    }

    public void PressResume()
    {
        resumeMenu.SetActive(false);
        pause.interactable = true;
        Time.timeScale = 1f;
    }
}
