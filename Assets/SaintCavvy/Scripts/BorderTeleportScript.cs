using UnityEngine;
using UnityEngine.Rendering.UI;

public class BorderTeleportScript : MonoBehaviour
{
    public float TeleportOffset;
    private Vector2 teleportTo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.position.x > 0)
        {
            teleportTo = new Vector2(-(other.transform.position.x - TeleportOffset), other.transform.position.y);
        }
        else if (other.transform.position.x < 0)
        {
            teleportTo = new Vector2(-(other.transform.position.x + TeleportOffset * 2), other.transform.position.y);
        }
        other.transform.position = teleportTo;
    }
}
