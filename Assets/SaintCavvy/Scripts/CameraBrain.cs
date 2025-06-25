using UnityEngine;

public class CameraBrain : MonoBehaviour
{
    [SerializeField] private float yOffset;
    public float CameraSpeed;
    private Vector3 dir;

    private void Start()
    {
        dir = new Vector3(0f, 0f, -10f);
    }

    private void Update()
    { 
        ProcessCameraMovement();
    }

    private void ProcessCameraMovement()
    {
        if (dir.y != transform.position.y)
        {
            gameObject.transform.position = Vector3.Lerp(transform.position, dir, CameraSpeed * Time.deltaTime);
        }
    }

    public void SetDirection(Vector3 pos)
    {
        dir.y = pos.y + yOffset;
    }
}
