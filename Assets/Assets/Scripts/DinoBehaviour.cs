using UnityEngine;
using UnityEngine.InputSystem;

public class DinoBehaviour : MonoBehaviour
{
    public bool IS_ALIVE = true;
    private bool IS_GROUNDED;
    private Rigidbody2D dinoRigidbody; 
    private float _jumpHeight = 10f;
    private float _rayLength = 1.0f;
    public LayerMask _groundLayer;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f; 
        IS_ALIVE = true;  
        dinoRigidbody = GetComponent<Rigidbody2D>();

        //check if rb is working
        //if (dinoRigidbody == null) {Debub.LogError["yo we're cooked rb dont work :/"];}
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.started && IS_GROUNDED)
        {
            dinoRigidbody.linearVelocity = new Vector2(dinoRigidbody.linearVelocityX, _jumpHeight);
        }
    }
 
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D playerRaycast = Physics2D.Raycast(transform.position, Vector2.down, _rayLength, _groundLayer);
        IS_GROUNDED = playerRaycast.collider != null;


    }
}
