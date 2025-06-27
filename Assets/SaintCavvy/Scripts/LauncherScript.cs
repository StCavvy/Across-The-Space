using UnityEngine;
using UnityEngine.Events;

public class LauncherScript : MonoBehaviour
{
    private Transform Destination;
    private float playerMass;
    private float jumpHeight;
    private float gravityForce;

    private UnityEvent Launched;

    private void Start()
    {
        Destination = transform.GetChild(0);
        jumpHeight = Destination.position.y - transform.position.y;
        gravityForce = -Physics.gravity.y;
        Launched.AddListener(Camera.main.GetComponent<CameraBrain>().FollowMode);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.collider.tag == "Player")
        {
            playerMass = collision.gameObject.GetComponent<Rigidbody2D>().mass;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * CalculateThrust(playerMass), ForceMode2D.Impulse);
            Launched.Invoke();
        }
    }

    private float CalculateThrust(float playerMass)
    {
        return Mathf.Sqrt(2f * gravityForce * jumpHeight);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.GetChild(0).position);
        Gizmos.DrawSphere(transform.GetChild(0).position, 0.5f);

    }
}
