using System;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject player1Text;
    [SerializeField]
    public GameObject player2Text;
    [SerializeField]
    public GameObject gameText;

    private int player1Score = 0;
    private int player2Score = 0;

    public void Player1Scored()
    {
        player1Score++;
        UpdateScoreText(1f);
    }

    public void Player2Scored()
    {
        player2Score++;
        UpdateScoreText(1f);
    }

    void ResetGame()
    {
        FindAnyObjectByType<BallController>().ResetBall();
        Array.ForEach(FindObjectsByType<PlayerController>(FindObjectsSortMode.None), player => player.Reset());
    }

    public void UpdateScoreText(float delay)
    {
        player1Text.GetComponent<TextMeshProUGUI>().text = player1Score.ToString();
        player2Text.GetComponent<TextMeshProUGUI>().text = player2Score.ToString();

        var suffix = "\nPress Space to play again";
        if (player1Score == 5)
        {
            gameText.GetComponent<TextMeshProUGUI>().text = "Player 1 Wins!" + suffix;
        }
        else if (player2Score == 5)
        {
            gameText.GetComponent<TextMeshProUGUI>().text = "Player 2 Wins!" + suffix;
        }
        else
        {
            Invoke(nameof(ResetGame), delay);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText(5f);
        gameText.GetComponent<TextMeshProUGUI>().text = "Welcome!\nPlayer 1 uses W and S\nPlayer 2 uses Up and Down\nFirst to 5 wins!";
        Invoke(nameof(StartGame), 5f);
    }

    void StartGame()
    {
        ResetGame();
        gameText.GetComponent<TextMeshProUGUI>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if ((player1Score == 5 || player2Score == 5) && Input.GetKeyDown(KeyCode.Space))
        {
            player1Score = 0;
            player2Score = 0;
            Start();
        }
    }
}
