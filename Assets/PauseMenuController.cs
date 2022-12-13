using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    // The canvas group containing the pause menu UI
    public GameObject pauseMenuLayers;
    private bool tracker = true;

    void Update()
    {
        // Check if the pause key (Esc) has been pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doPauseUpdate();
        }
    }
    private void doPauseUpdate()
    {
        // Toggle the pause menu by enabling/disabling the canvas group
        pauseMenuLayers.SetActive(tracker);

        if (tracker)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        tracker = !tracker;
    }
    public void resumeButton()
    {
        pauseMenuLayers.SetActive(false);
        Time.timeScale = 1;
        tracker = true;
    }
}
