using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    private BallMovement ballMovement;
    private LivesManager livesManager;
    private ScoreManager scoreManager;
    private LevelManager levelManager;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelStatusText;

    private GameObject playAgainButton; 

    // Start is called before the first frame update
    void Start()
    {
        ballMovement = FindObjectOfType<BallMovement>();
        livesManager = FindObjectOfType<LivesManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        levelManager = FindObjectOfType<LevelManager>();

        levelStatusText.enabled = true;
        levelStatusText.text = "Press Space Bar To Play";

        playAgainButton = GameObject.Find("Play Again Button");
        playAgainButton.SetActive(false);

        playAgainButton.GetComponent<Button>().onClick.AddListener(levelManager.RestartLevel);
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = livesManager.lives.ToString();
        scoreText.text = scoreManager.score.ToString();

        if(levelManager.levelComplete)
        {
            levelStatusText.enabled = true;
            levelStatusText.text = "Level Complete!";

            playAgainButton.SetActive(true);
        } else if(livesManager.gameOver)
        {
            levelStatusText.enabled = true;
            levelStatusText.text = "Game Over!";

            playAgainButton.SetActive(true);
        } else if(livesManager.lifeLost)
        {
            levelStatusText.enabled = true;
            levelStatusText.text = "Press Space Bar To Play";
        } else if(ballMovement.spaceBarPressed)
        {
            levelStatusText.enabled = false;
            ballMovement.spaceBarPressed = false;
        }
    }
}
