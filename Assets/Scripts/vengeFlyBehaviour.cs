using System;
using UnityEngine;

public class vengeFlyBehaviour : MonoBehaviour
{
    
    bool followingPlayer = false;
    Vector2 playerPosition;
    public float moveSpeed = 0.5f;
    private int health = 2;
    
    private void FixedUpdate()
    {
        followPlayer();
    }

    private void followPlayer()
    {

        if (followingPlayer) 
        {
            if (Vector2.Distance(transform.position, playerPosition) > 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPosition, moveSpeed);
            }
            else 
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPosition, 0.05f);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerPosition = collision.transform.position;
            followingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        followingPlayer = false;
    }
    
}
