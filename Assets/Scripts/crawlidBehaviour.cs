using UnityEngine;

public class crawlidBehaviour : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField]
    private float speed = 2f;
    public bool movingRight = true;
    [Header("Detección")]
    public Transform groundCheck;
    public Transform wallCheck;
    public float checkDistanceX = 1f;
    public float checkDistanceY = 1.5f;
    private float groundCheckPositionX;
    public LayerMask layerMaskWall;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    //
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        groundCheckPositionX = groundCheck.transform.localScale.x;
        // Operador ternario para dirección, primer valor si es true, segundo si es false
        float moveDir = movingRight ? 1f : -1f;
        rb.linearVelocity = new Vector2(moveDir * speed, rb.linearVelocity.y);

        // Detectar pared y falta de suelo
        bool hitWall = Physics2D.Raycast(wallCheck.position, movingRight ? Vector2.right : Vector2.left, checkDistanceX, layerMaskWall);
        bool noGround = !Physics2D.Raycast(groundCheck.position, Vector2.down, checkDistanceY, layerMaskWall);

        // Cambiar dirección
        if (hitWall || noGround)
        {
            Flip();
            
        }
    }

    private void Update()
    {
        // Debug Rays
        Debug.DrawRay(wallCheck.position, (movingRight ? Vector2.right : Vector2.left) * checkDistanceX, Color.red);
        //CircleCast
        Debug.DrawRay(groundCheck.position, Vector2.down * checkDistanceY, Color.cyan);

    }

    void Flip()
    {
        Debug.Log("Flip");
        //rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Detener el movimiento horizontal antes de girar
        movingRight = !movingRight;
        // Invierte solo el sprite (no el transform completo)
        spriteRenderer.flipX = true;
        wallCheck.transform.localScale = new Vector2(-wallCheck.localScale.x, wallCheck.localScale.y);
    }
}