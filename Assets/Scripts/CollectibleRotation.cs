using UnityEngine;

public class CollectibleRotation : MonoBehaviour
{
    [SerializeField] private int rotSpeed;
    void Start()
    {
        InvokeRepeating(nameof(RotCollectible),2f, 0.02f);
    }

    private void RotCollectible()
    {
        transform.Rotate(gameObject.CompareTag("Bomb") ? Vector3.right : Vector3.up, 10f * rotSpeed * Time.deltaTime);
    }
}
