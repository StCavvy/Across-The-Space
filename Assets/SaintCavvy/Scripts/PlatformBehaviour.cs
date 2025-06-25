using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null && collider.tag == "Player")
        {
            ChangeState(DefinePLayerPos(collider));
        }
    }
    private void ChangeState(bool state)
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = state;
    }

    private bool DefinePLayerPos(Collider2D Player)
    {
        bool isAbove;
        if (gameObject.transform.position.y < Player.transform.position.y)
        {
            isAbove = true;
        }
        else isAbove = false;

        return isAbove;
    }
}
