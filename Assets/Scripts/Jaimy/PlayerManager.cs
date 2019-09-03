using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;

    public static Action<Player, float> PLAYER_DAMAGE;

    [SerializeField] private GameObject greenWon;
    [SerializeField] private GameObject redWon;

    public static PlayerManager GetInstance()
    {
        return instance;
    }

    [SerializeField]
    [Range(0, 4)]
    private int maxPlayers;

    [SerializeField]
    private List<Player> onlinePlayers = new List<Player>();

    [SerializeField]
    private GameObject playerPrefab;

    void Awake()
    {
        instance = this;

        // Create a amount of players
        for (int i = 0; i < maxPlayers; i++)
        {
            GameObject gameObject = Instantiate(playerPrefab);

            Player player = new Player(i, gameObject);

            onlinePlayers.Add(player);

            gameObject.GetComponent<Smash>().player = player;
            gameObject.GetComponent<Defense>().player = player;
            gameObject.GetComponent<PlayerMovement>().player = player;
        }
    }

    void Start()
    {
        PLAYER_DAMAGE += OnPlayerDamage;
    }

    public Player GetPlayer(long id)
    {
        foreach(Player p in onlinePlayers)
        {
            if (p.GetId() == id) return p;
        }

        return null;
    }

    public int GetPlayerAmount()
    {
        return onlinePlayers.Count;
    }

    public List<Player> GetPlayers()
    {
        return onlinePlayers;
    }

    public void OnPlayerDamage(Player player, float health)
    {
        if (health == 0)
        {
            onlinePlayers.Remove(player);
            Destroy(player.GetGameObject());

            if (onlinePlayers.Count == 1)
            {
                Player winner = onlinePlayers[0];

                if (winner.GetId() == 0)
                {
                    greenWon.SetActive(true);
                } else if (winner.GetId() == 1)
                {
                    redWon.SetActive(true);
                }

                StartCoroutine(ResetScene());
            }
        }

        Debug.Log("Player with id: " + player.GetId() + " his health is now " + health);
    }

    private IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(10f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
public enum DefenseType
{
    NONE, UP, MID, DOWN
}
