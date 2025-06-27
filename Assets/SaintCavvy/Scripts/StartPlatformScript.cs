using UnityEngine;

public class StartPlatformScript : MonoBehaviour
{
    public float LevelHeight;
    private Vector2 leftBorder;
    private Vector2 rightBorder;
    private float screenRadius;
    private void Reset()
    {
        screenRadius = (Camera.main.orthographicSize * Camera.main.aspect);
        leftBorder = new Vector2(-screenRadius, 0);
        rightBorder = new Vector2(screenRadius, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(leftBorder, transform.up * LevelHeight);
        Gizmos.DrawRay(rightBorder,transform.up * LevelHeight);
    }

}
