using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text highScoreDisplay;
    public Text currentScoreDisplay;

    private string highScoreFormat;
    private string currentScoreFormat;

    private void Start()
    {
        highScoreFormat = highScoreDisplay.text;
        currentScoreFormat = currentScoreDisplay.text;
    }

    private void Update()
    {
        if (highScoreDisplay != null)
        {
            highScoreDisplay.text = string.Format(highScoreFormat, PlayerPrefs.GetInt("HighScore", 0));
        }

        if (currentScoreDisplay != null)
        {
            currentScoreDisplay.text = string.Format(currentScoreFormat, PlayerPrefs.GetInt("CurrentScore", 0));
        }
    }
}
