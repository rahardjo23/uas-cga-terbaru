using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the score text UI
    public float scoreIncreaseRate = 20f; // Score increment per second
    private float score = 0f;
    private bool isPlayerAlive = true; // Made public for debugging
    private bool isGameOver = false;

    void Update()
    {
        if (isPlayerAlive)
        {
            score += scoreIncreaseRate * Time.deltaTime;
            scoreText.text = $"Score: {Mathf.FloorToInt(score)}";
        }
        else
        {
            Debug.Log("Score stopped updating. Player is not alive.");
        }
    }


    public void PlayerDied()
    {
        Debug.Log("PlayerDied method called");
        isPlayerAlive = false;
        isGameOver = true;
    }

    public void ResetScore()
    {
        score = 0;
        isGameOver = false;
    }

}
