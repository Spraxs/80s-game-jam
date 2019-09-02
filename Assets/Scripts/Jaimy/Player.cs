using UnityEngine;
public class Player : ScriptableObject
{
    private long id;
    private GameObject gameObject;

    private float health;

    public DefenseType defenseType;

    public Player(long id, GameObject gameObject)
    {
        this.id = id;
        this.gameObject = gameObject;
        health = 100f;
    }

    public void Damage(float damage)
    {
        health -= damage;

        if (health < 0) health = 0;

        if (PlayerManager.PLAYER_DAMAGE == null) return;
        PlayerManager.PLAYER_DAMAGE(this, health);
    }

    public long GetId()
    {
        return id;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public bool IsInRange(Player player, float range)
    {
        return Vector3.Distance(gameObject.transform.position, player.GetGameObject().transform.position) < range;
    }

    public bool IsFacingPlayer(Player player)
    {
        // If scale is -1, character is facing left. Is scale is 1, character is facing right.

        return (gameObject.transform.localScale.x > 0 && player.gameObject.transform.position.x > gameObject.transform.position.x
            || gameObject.transform.localScale.x < 0 && player.gameObject.transform.position.x < gameObject.transform.position.x);
    }

    public static Player ById(long id)
    {
        return PlayerManager.GetInstance().GetPlayer(id);
    }
}
