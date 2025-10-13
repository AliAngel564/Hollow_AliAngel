using System;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public GameObject geoCoin;
    public ParticleSystem deathParticle;
    Transform vengeFlyTransform;
    Rigidbody2D vengeFlyRigidbody2D;
    [SerializeField]private int health, maxHealth = 3;
    [SerializeField]private float knockbackForce = 3f;
    

    private void Awake()
    {
        vengeFlyRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        vengeFlyTransform = GetComponent<Transform>();
        health = maxHealth;
    }
    private void Update()
    {
        Death();
    }
    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        Knockback();
        Debug.Log("vida: "+health);
    }

    private void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        for (var i = 0; i < 3; i++)
        {
            Instantiate(geoCoin, vengeFlyTransform.position, Quaternion.identity);
        }
        var deathParticles = Instantiate(deathParticle, vengeFlyTransform.position, Quaternion.identity);
        Destroy(deathParticles, 5f);
        
    }

    private void Knockback()
    {
        vengeFlyRigidbody2D.AddForce(-vengeFlyTransform.right *knockbackForce, ForceMode2D.Impulse);
    }
}
