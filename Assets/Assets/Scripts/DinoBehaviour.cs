using UnityEngine;

public class DinoBehaviour : MonoBehaviour
{
    public bool IS_ALIVE = true;
    private bool IS_GROUNDED;
    private Rigidbody2D dinoRigidbody; 

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f; 
        IS_ALIVE = true;  
        dinoRigidbody = GetComponent<Rigidbody2D>();

        //check if rb is working
        //if (dinoRigidbody == null) {Debub.LogError["yo we're cooked rb dont work :/"];}
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
}
