using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class characterAttack : MonoBehaviour
{
    enemyHealth enemyHealth;
    
    private playerInput input;
    private InputAction attackInput;
    
    [SerializeField]private GameObject attackCollider;
    [SerializeField]private Collider2D attackCollision;
    
    private Transform playerTransform;

    private float impulseForce = 10f;
    public int damageAmount = 3;

    private void Awake()
    {
        playerTransform = GetComponent<Transform>();
        input = new playerInput();
        attackInput = input.FindAction("attack");
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        if (attackInput.IsPressed())
        {
            attackCollision.enabled = true;
        }
        else
        {
            attackCollision.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger & collision.gameObject.TryGetComponent<enemyHealth>(out enemyHealth enemyHealth))
        {
            enemyHealth.takeDamage(damageAmount);
        }
              
    }
}
