using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    private int currentHealth;
    public int maxHealth;

    public float invincibilityLength = 1f;
    public float invincCounter = 0f;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        FillHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;    
        }
    }

    public void DamagePlayer()
    {
        if (invincCounter <= 0)
        {
            invincCounter = invincibilityLength;
            currentHealth -= 1;

            if (currentHealth <= 0)
            {
                LevelManager.instance.Respawn();
            }
        }
    }

    public void FillHealth()
    {
        currentHealth = maxHealth;
    }
}
