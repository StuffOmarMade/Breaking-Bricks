using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    private Rigidbody2D rb2d;

    private LivesManager livesManager;
    private LevelManager levelManager;

    private Vector3 pos;
    private Vector3 ballVelocity;

    public bool spaceBarPressed;
    private bool yetToPlay;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        livesManager = GetComponent<LivesManager>();
        levelManager = FindObjectOfType<LevelManager>();

        pos = transform.position;

        // acts as a flag as to whether the space bar is pressed or not. This helps hide the "Press Space Bar To Play" text(UIManager).
        spaceBarPressed = false;


        yetToPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        ManageBall();
        
        // sets the continuously updated velocity of the ball to the var called ballVelocity
        ballVelocity = rb2d.velocity;

    }

    void ManageBall()
    {
        // in case player is yet to start playing(starting the level) then call Launch Ball.
        if (yetToPlay)
        {
            LaunchBall();
        } else if(livesManager.lifeLost && yetToPlay == false) // in case a life is lost and it the player has already begun playing the level, reset ball, then launch the ball.
        {
            ResetBall();
            LaunchBall();
        } else if(livesManager.gameOver || levelManager.levelComplete) // if game is over or level is complete, reset ball position.
        {
            ResetBall();
        }
    }

    void LaunchBall()
    {
        // Launch ball when player releases the space bar
        if (Input.GetKeyUp(KeyCode.Space))
        {
            spaceBarPressed = true;

            // Add force to the ball to move the ball either to the right or to the left
            Vector2 startingVelocity = (Random.value < 0.5) ? new Vector2(160, -320) : new Vector2(-160, -320);
            rb2d.AddForce(startingVelocity);
            livesManager.lifeLost = false;
            
            // player is no longer starting the level for the first time.
            yetToPlay = false;
        }    
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "LowerBound")
        {
            // sets the magnitude of the velocity vector to the var speed
            float speed = ballVelocity.magnitude;

            /* 
            calculates the direction to bounce the ball in by reflecting the direction the ball is hitting
            the normal of the surface the ball is colliding with
            */

            // why is the ballVelocity vector normalized?
            Vector3 direction = Vector3.Reflect(ballVelocity.normalized, col.contacts[0].normal);

            // sets the new value/vector of the velocity vector of the ball
            rb2d.velocity = direction * speed;    
        }
    }

    void ResetBall()
    {
        // reset ball position to the position(pos) vector, and the direction and speed (velocity) to zero
        gameObject.transform.position = pos;
        rb2d.velocity = new Vector2(0, 0);
    }
}
