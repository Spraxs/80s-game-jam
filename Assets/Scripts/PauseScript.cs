using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseUI;
    public bool paused = false;
    public GameObject PauseScreen;
    // Start is called before the first frame update
    void Awake()
    {
        PauseUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen.SetActive(true);
            TogglePause();
        }
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            PauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void TogglePause()
    {
        paused = !paused;
    }
}
