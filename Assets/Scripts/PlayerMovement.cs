using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Speed at which the paddle moves
    public float speed;
    
    // Paddle's transform
    private Vector3 objPos;
    private Vector3 defaultPos;

    private float minScreenBoundsX;
    private float maxScreenBoundsX;

    private LivesManager livesManager;

    // Start is called before the first frame update
    void Start()
    {
        /* 
        The min and max screen bounds to prevent paddle from exiting the screen
        ScreenToWorldPoint: 
        */
        // minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        // maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        livesManager = FindObjectOfType<LivesManager>();
        
        defaultPos = transform.position;

        minScreenBoundsX = -6f;
        maxScreenBoundsX = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (livesManager.lifeLost == false)
        {
            // Move the paddle horizontally (per user input)
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, 0);
                
            // Current paddle position 
            objPos = transform.position;

            // Clamp paddle's x position between minScreenBounds and maxScreenBounds
            transform.position = new Vector2(Mathf.Clamp(objPos.x, minScreenBoundsX, maxScreenBoundsX), objPos.y);            
        } else if(livesManager.lifeLost)
        {
            // if life lost, reset paddle position.
            transform.position = defaultPos;
        }
    }
}
