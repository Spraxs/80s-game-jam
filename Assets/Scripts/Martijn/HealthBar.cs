using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Player player { get; set; }
    public Image Fill;

    public Slider healthBar;

    private PlayerManager playerManager;

    void Start()
    {
        player = GetComponent<Smash>().player;

        if (player.GetId() == 0){
            Fill.color = new Color(0, 1, 0, 1);
        
      }
        else if (player.GetId() == 1)
        {
            Fill.color = new Color(1, 0, 0, 1);

        }
        else if (player.GetId() == 2)
        {
            Fill.color = new Color(0, 0, 0, 1);

        }
        else if (player.GetId() == 3)
        {
            Fill.color = new Color(0, 1, 1, 1);

        }

       

        PlayerManager.PLAYER_DAMAGE += OnDamage;



        healthBar.value = CalculateHealth();
    }
    private void OnDamage(Player player, float health)
    {
 

        
        if (player.GetId() == this.player.GetId())
        {
            Debug.Log(healthBar.value);
            healthBar.value = CalculateHealth();
        }
      
    }
    float CalculateHealth()
    {
        
        return player.health / 100f;
    }
    
   
}
