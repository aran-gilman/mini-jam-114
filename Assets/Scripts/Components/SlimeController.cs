using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{
    public float initialSpeed;
    public Direction direction;
    public int pointValue;

    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

            int oldScore = PlayerPrefs.GetInt("CurrentScore", 0);
            PlayerPrefs.SetInt("CurrentScore", oldScore + pointValue);
        }
        else if (collision.CompareTag("Player"))
        {
            int oldHighScore = PlayerPrefs.GetInt("HighScore", 0);
            int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
            if (currentScore > oldHighScore)
            {
                PlayerPrefs.SetInt("HighScore", currentScore);
            }
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void Start()
    {
        rb.velocity = DirectionUtil.ToVector(direction) * initialSpeed;
    }
}
