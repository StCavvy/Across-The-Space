using UnityEngine;

public class StartPlatformScript : MonoBehaviour
{
    public float LevelHeight;
    private Vector2 leftBorder;
    private Vector2 rightBorder;
    private float screenRadius;

    private void OnDrawGizmos()
    {
        screenRadius = (Camera.main.orthographicSize * Camera.main.aspect);
        leftBorder = new Vector2(-screenRadius, 0);
        rightBorder = new Vector2(screenRadius, 0);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(leftBorder, transform.up * LevelHeight);
        Gizmos.DrawRay(rightBorder,transform.up * LevelHeight);
    }
}
