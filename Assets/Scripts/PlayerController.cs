using Unity.Mathematics;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rBody;
    public bool canMove;
    [Range(1,10)] public float movementFactor;

    public GameObject coinVfx;
   public GameObject bombVfx;
    private VisualEffect vfx;
    
    
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameManager gameManagerScript;
    void Start()
    {
        
        rBody = GetComponent<Rigidbody>();
        canMove = true;
        InvokeRepeating(nameof(PlayerMovement), 2f, 0.02f);
    }

    private void PlayerMovement()
    {
        if(canMove)
            rBody.velocity= new Vector3(joystick.Horizontal * movementFactor, 0f, joystick.Vertical * movementFactor);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Instantiate(coinVfx, transform.position, quaternion.identity);
            gameManagerScript.score++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Bomb"))
        {
            Instantiate(bombVfx, transform.position, quaternion.identity);
            canMove = false;
            rBody.velocity = Vector3.zero;
            Destroy(other.gameObject);
            gameManagerScript.playerDead = true;
            gameManagerScript.gameOverText.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void VfxPlayer(VFXEventAttribute attribute)
    {
        vfx.Play(attribute);
    }
}
