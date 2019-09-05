using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private Text wonText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame(Player winner)
    {
        wonText.gameObject.SetActive(true);
        if (winner.GetId() == 0)
        {

            wonText.text = "GREEN HAS WON";
            wonText.color = Color.green;
        }
        else if (winner.GetId() == 1)
        {
            wonText.text = "RED HAS WON";
            wonText.color = Color.red;
        }

        StartCoroutine(ResetScene());
    }

    private IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(10f);

        wonText.gameObject.SetActive(false);

        SceneManager.LoadScene(0);
    }
}
