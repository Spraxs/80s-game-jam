using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Player player { get; set; }
  

    public Slider healthBar;

    private PlayerManager playerManager;

    void Start()
    {

        player = GetComponent<Smash>().player;

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
