using UnityEngine;
using UnityEngine.InputSystem;

public class DinoBehaviour : MonoBehaviour
{
    public bool IS_ALIVE = true;
    private bool IS_GROUNDED;
    private Rigidbody2D dinoRigidbody; 
    private float _jumpHeight = 5f;
    private float _rayLength = 1.0f;
    public LayerMask _groundLayer;
    public AudioClip jumpSound;
    private AudioSource playerAudio;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

        Time.timeScale = 1.0f; 
        IS_ALIVE = true;  
        dinoRigidbody = GetComponent<Rigidbody2D>();

        //check if rb is working
        //if (dinoRigidbody == null) {Debub.LogError["yo we're cooked rb dont work :/"];}
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("Barrier Hit");
            Time.timeScale = 0f;
            IS_ALIVE = false;
        }
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if(context.started && IS_GROUNDED && IS_ALIVE)
        {
            dinoRigidbody.linearVelocity = new Vector2(dinoRigidbody.linearVelocityX, _jumpHeight);
        }
    }
 
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D playerRaycast = Physics2D.Raycast(transform.position, Vector2.down, _rayLength, _groundLayer);
        IS_GROUNDED = playerRaycast.collider != null;

        if (Input.GetButtonDown("Jump"))
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

    }
}
