using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text highScoreDisplay;
    public Text currentScoreDisplay;

    private void Update()
    {
        highScoreDisplay.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
        currentScoreDisplay.text = $"Current Score: {PlayerPrefs.GetInt("CurrentScore", 0)}";
    }
}
