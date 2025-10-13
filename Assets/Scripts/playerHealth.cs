using System;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField]private int health;
    [SerializeField]private int maxHealth = 3;

    private void Awake()
    {
        health = maxHealth;
    }

    private void Update()
    {
        Debug.Log("Pepino's Health:"+health);
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }
}
