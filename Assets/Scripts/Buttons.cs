using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackHomeMenu()
    {
        SceneManager.LoadScene("HomeMenu");
    }
    public void CharacterSelect()
    {
        SceneManager.LoadScene("CharacterSelect");
    }
    public void BeginGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
