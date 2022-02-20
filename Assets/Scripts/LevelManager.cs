using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool levelComplete;
    
    public List<Transform> bricks;

    // Start is called before the first frame update
    void Start()
    {
        // acts as a flag as to whether the level is complete or not.
        levelComplete = false;

        // list containing all transform components of the brick's(parent) children.
        bricks = new List<Transform>();

        // loops through each of the children and adding their transform to the bricks list, excluding the parent.
        foreach (Transform brick in transform.GetComponentsInChildren<Transform>())
        {
            if (brick.gameObject != gameObject)
            {
                bricks.Add(brick);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if all bricks are destroyed, then the level is complete.
        if (bricks.Count == 0)
        {
            levelComplete = true;
        }
    }

    public void RestartLevel()
    {
        // method responsible for restarting/reseting scene
        SceneManager.LoadScene("Level 1");
    }
}