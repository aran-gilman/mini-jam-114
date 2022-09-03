using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour, IMoving
{
    public float initialSpeed;
    public int pointValue;

    public Rigidbody2D rb;
    public Health health;

    public float InitialSpeed { get => initialSpeed; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            collision.GetComponent<Projectile>().Destroy();
            health.Change(-1);
            if (!health.IsAlive)
            {
                int oldScore = PlayerPrefs.GetInt("CurrentScore", 0);
                PlayerPrefs.SetInt("CurrentScore", oldScore + pointValue);
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();
            playerHealth.Change(-1);
            if (!playerHealth.IsAlive)
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
    }
}
