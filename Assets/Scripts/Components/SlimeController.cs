using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour, IMoving
{
    public float initialSpeed;
    public int pointValue;

    public Rigidbody2D rb;

    public float InitialSpeed { get => initialSpeed; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            collision.GetComponent<Projectile>().Destroy();

            int oldScore = PlayerPrefs.GetInt("CurrentScore", 0);
            PlayerPrefs.SetInt("CurrentScore", oldScore + pointValue);
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
