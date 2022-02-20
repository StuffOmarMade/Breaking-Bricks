using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrick : MonoBehaviour
{

    private string[] tags;
    
    public string brickDestroyed;
    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        // an array with all the brick types/tags
        tags = new string[] {
                            "Red Brick", "Orange Brick", "Dark Orange Brick",
                             "Yellow Brick", "Green Brick", "Purble Brick"
                            };

        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        /*
            on collision, loop through tags and check if the tag of the brick destroyed 
            matches the current tags[index], if so, assign the tag to brickDestroyed which will be later
            used to identify the amount of points to be added to the player's score. Then destroy brick.
        */
        for (int i = 0; i < tags.Length; i++)
        {
            // Destroy the brick the player collides with
            if(col.gameObject.tag == tags[i])
            {
                brickDestroyed = tags[i];
                levelManager.bricks.Remove(col.gameObject.transform);
                Destroy(col.gameObject);
                break;
            }
        }   
    }
}
