using UnityEngine;


public class playerMovement : MonoBehaviour
{
    private PlayerInput input;

    public float movementSpeed;
    public float jumpStrenght;
    public bool touchingGrass;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private Animator _animator;

    private Vector2 _moveDirection;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();   
    }
    private void FixedUpdate()
    {
        handleMovement();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        _animator.SetBool("isGrounded", true);


    }

    //No es lo más optimo pero funciona por ahora para arreglar la caida infinita
    private void OnCollisionStay2D(Collision2D collision)
    {
        _animator.SetBool("isGrounded", true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _animator.SetBool("isGrounded", false);
    }
    private void handleMovement()
    {
        if (_animator.GetBool("isGrounded") == true)
        {
            _animator.SetBool("isJumping", false);
        }
       
        _moveDirection = input.Player.movement.ReadValue<Vector2>();
        if (input.Player.jump.WasPressedThisFrame() && _animator.GetBool("isGrounded") == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpStrenght);
            _animator.SetBool("isJumping", true);
        }
        Vector2 moveAmt = new Vector2(_moveDirection.x * movementSpeed, rb.linearVelocity.y);
        rb.linearVelocity = moveAmt;

        if (rb.linearVelocity.x != 0)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
        if (_moveDirection.x == -1)
        {
            spriteRenderer.flipX = true;
        }
        else if (_moveDirection.x == 1)
        {
            spriteRenderer.flipX = false;
        }

    }
}




