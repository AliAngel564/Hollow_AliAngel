using Unity.VisualScripting;
using UnityEngine;

public class crawlidBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private Rigidbody2D crawlidRB;
    private BoxCollider2D crawlidCollider;
    private Transform crawlidTransform;

   
    void Start()
    {
        crawlidRB = GetComponent<Rigidbody2D>();
        crawlidCollider = GetComponent<BoxCollider2D>();
        crawlidTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        crawlidRB.AddForceAtPosition(Vector2.right, crawlidTransform.position);
    }

    
       


}
