using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {

    public int curHealth;
    public int maxHealth = 5;



    void Start ()
    {
      
        curHealth = maxHealth;
    }

    public void EditLive(int Hp)
    {
        curHealth += Hp;
    }
   

    void Update()
    {
       
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 0)
        {

        }

    }

    void Die()
    {
        curHealth = 0;
        Debug.Log("You died.");
    }
}


    





