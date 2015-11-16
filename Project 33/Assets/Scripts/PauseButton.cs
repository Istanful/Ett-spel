using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseButton : MonoBehaviour {
    public Sprite pauseIcon;
    public Sprite resumeIcon;

    Image imageScript;
    bool isPaused = false;

    void Start()
    {
        imageScript = GetComponent<Image>();
        imageScript.sprite = pauseIcon;
    }

    void OnApplicationFocus(bool focusStatus)
    {
        if (!focusStatus)
        {
            isPaused = false;
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            imageScript.sprite = resumeIcon;
            isPaused = !isPaused;
        }
        else
        { 
            Time.timeScale = 1;
            imageScript.sprite = pauseIcon;
            isPaused = !isPaused;
        }
    }
}
