using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float playerHealth = 10;
    private float maxPlayerHealth;
    public bool playerIsDead;

    private void Start()
    {
        maxPlayerHealth = playerHealth;
    }

    public void DamagePlayer(float damageValue)
    {
        playerHealth -= damageValue;
        Debug.Log("Player Attacked");

        if (playerHealth <= 0f)
        {
            playerHealth = 0f;
            playerIsDead = true;
        }
    }

    public void HealPlayer(float healingValue)
    {
        playerHealth += healingValue;

        if (playerHealth >= maxPlayerHealth) playerHealth = maxPlayerHealth;
    }
}
