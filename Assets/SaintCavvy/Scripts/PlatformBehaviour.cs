using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{


    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null && collider.tag == "Player")
        {
            ChangeState(isAbove(collider));
        }
    }
    private void ChangeState(bool state)
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = state;
    }

    private bool isAbove(Collider2D Player)
    {
        float playerHeigth = Player.transform.localScale.y / 2;
        bool isAbove;
        if (gameObject.transform.position.y < Player.transform.position.y - playerHeigth)
        {
            isAbove = true;
        }
        else isAbove = false;

        return isAbove;
    }
}
