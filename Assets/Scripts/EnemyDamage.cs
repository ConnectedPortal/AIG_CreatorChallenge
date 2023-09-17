using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private bool playerDetected;
    [SerializeField] private float attackValue = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //playerDetected = true;
            Debug.Log("Player Detected");
            DamagePlayer();
        }
    }

    private void DamagePlayer()
    {
        playerHealth.DamagePlayer(attackValue);
    }
}
