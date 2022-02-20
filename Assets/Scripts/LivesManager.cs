using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{

    public int lives;
    public bool lifeLost;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        // number of lives
        lives = 5;

        // acts as a flag to whether a life is lost or not
        lifeLost = false;

        // acts as a flag to whether game is over or not
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if the player loses all of their lives, then the game is over(player lost).
        if(lives == 0)
        {
            gameOver = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // if ball collides with the bottom of the screen, player loses a life.
        if(col.gameObject.tag == "LowerBound" && lives >= 1)
        {
            lives--;
            lifeLost = true;
        }
    }
}
