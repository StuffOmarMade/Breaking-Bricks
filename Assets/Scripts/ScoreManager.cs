using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int score;
    private DestroyBrick destroyBrick;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        destroyBrick = FindObjectOfType<DestroyBrick>();
    }

    // Update is called once per frame
    void Update()
    {
        manageScore();
    }

    void manageScore()
    {
        /*
            determines the amount of points to be added to player's score
            by comparing the brickDestroyed(tag of the brick destroyed) to the case.

            then set brickDestroyed to an empty string(which will not match any of the cases) as to
            avoid continuously adding points(looping) in DestroyBrick. 
        */
        switch (destroyBrick.brickDestroyed)
        {
            case "Purble Brick":
            case "Green Brick":
                score += 1;
                destroyBrick.brickDestroyed = "";
                break;

            case "Yellow Brick": 
            case "Orange Brick":
                score += 4;
                destroyBrick.brickDestroyed = "";
                break;

            case "Dark Orange Brick": 
            case "Red Brick":
                score += 7;
                destroyBrick.brickDestroyed = "";
                break;

            default:

                break;
        }
    }
}
