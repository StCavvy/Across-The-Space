using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float thrust = 5f;
    private Rigidbody2D rb;
    private float xValue;

    private UnityEvent StepOnPlatform;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StepOnPlatform.AddListener(Camera.main.GetComponent<CameraBrain>().SetOnPosition);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(xValue * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6 && rb.linearVelocity.y < 0f)
        {
            Jump();
            StepOnPlatform.Invoke();
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
