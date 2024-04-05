using UnityEngine;
using TMPro; 

public class GameUIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Drag score TextMeshProUGUI element here in the Inspector
    public TextMeshProUGUI timerText;

    private float timeRemaining = 60;
    private int score = 0;

    void Update()
    {
        // Timer countdown
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
        }

        // Update score display (this part would usually be triggered by some game event)
        scoreText.text = "Score: " + score.ToString();
    }

    // Call this method to increase score
    public void IncreaseScore(int points)
    {
        score += points;
    }
}
