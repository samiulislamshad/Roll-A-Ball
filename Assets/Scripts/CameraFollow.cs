using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Rigidbody playerRBody;
    [Range(0,1)] public float smoothFactor;
    [SerializeField] private Vector3 cameraOffset;
    void Start()
    {
        playerRBody = player.GetComponent<Rigidbody>();
        InvokeRepeating(nameof(FollowPlayer),2f,0.02f);
    }

    private void FollowPlayer()
    {
        if (player == null) return;
        var currentPos = transform.position;
        var targetPos = player.transform.position + cameraOffset;
        transform.position = Vector3.Lerp(currentPos, targetPos, smoothFactor);
    }
    
}
