using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine;

public class PayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float thrust = 5f;
    private Rigidbody2D rb;
    private float xValue;

    public UnityEvent<Vector3> StepOnPlatform;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.linearVelocity = new Vector2(xValue * moveSpeed, rb.linearVelocity.y);
        Debug.Log(xValue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Jump();
            StepOnPlatform.Invoke(collision.transform.position);
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
    }
    public void ProcessMovement(InputAction.CallbackContext context)
    {
        xValue = context.ReadValue<Vector2>().x;
    }
}
