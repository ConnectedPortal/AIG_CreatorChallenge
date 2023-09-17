using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseTriggers : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject cheese;
    [SerializeField] private float healingValue = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Cheese");
            playerHealth.HealPlayer(healingValue);
            DeactivateCheese();
        }
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Cheese");
            DeactivateCheese();
        }
    }

    private void DeactivateCheese()
    {
        cheese.SetActive(false);
    }
}
