using UnityEngine;

public class LevelBordersScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject leftBorder;
    [SerializeField] private GameObject rightBorder;
    [SerializeField] private float borderOfScreenOffset;
    private Vector2 leftBorderPos;
    private Vector2 rightBorderPos;
    private Vector2 bordersPos;
    private float screenRadius;
    void Start()
    {
        screenRadius = (Camera.main.orthographicSize * Camera.main.aspect) + borderOfScreenOffset;
        bordersPos = new Vector2(0, player.position.y);
        SetBorders();
    }


    void Update()
    {
        FollowPlayer();
    }

    private void SetBorders()
    {
        leftBorderPos = new Vector2(-screenRadius, 0);
        rightBorderPos = new Vector2(screenRadius, 0);
        leftBorder.transform.position = leftBorderPos;
        rightBorder.transform.position = rightBorderPos;
    }

    private void FollowPlayer()
    {
        bordersPos.y = player.position.y;
        gameObject.transform.position = bordersPos;
    }
}
