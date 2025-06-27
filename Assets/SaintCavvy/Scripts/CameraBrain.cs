using UnityEngine;

public class CameraBrain : MonoBehaviour
{
    [SerializeField] private float yOffset;
    private GameObject player;
    public float CameraSpeed;
    private Vector3 dir;

    public enum CameraMode
    {
        FollowPlayer,
        SetOnPosition
    };

    public CameraMode mode;

    private void Start()
    {
        dir = new Vector3(0f, 0f, -10f);
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        ProcessCameraMovement();
    }

    private void ProcessCameraMovement()
    {
        switch (mode)
        {
            case CameraMode.FollowPlayer:
                dir.y = player.transform.position.y;
                break;
            case CameraMode.SetOnPosition:
                break;
        }

        gameObject.transform.position = Vector3.Lerp(transform.position, dir, CameraSpeed * Time.deltaTime);
        
    }

    public void SetOnPosition() 
    {
        dir.y = player.transform.position.y + yOffset;
        mode = CameraMode.SetOnPosition;
    }

    public void FollowMode()
    {
        mode = CameraMode.FollowPlayer;
    }
}
