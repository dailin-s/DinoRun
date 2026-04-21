using UnityEngine;

public class BarrierBehaviour : MonoBehaviour
{
    private float _barrierMovementSpeed = 5f;
    private float _screenExit = -10f;
    private Rigidbody2D barrierRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        barrierRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * _barrierMovementSpeed * Time.deltaTime);

        if(transform.position.x < _screenExit)
        {
           Destroy(gameObject); 
        }
    }
}
