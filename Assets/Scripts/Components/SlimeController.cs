using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour, IMoving
{
    public float initialSpeed;
    public int pointValue;
    public AudioClip playerHitSound;

    public Rigidbody2D rb;
    public Health health;
    public PlaySfx sfxPlayer;

    public float InitialSpeed { get => initialSpeed; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            collision.GetComponent<Projectile>().Destroy();
            health.Change(-1);
            if (!health.IsAlive)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();
            playerHealth.Change(-1);
            sfxPlayer.Play(playerHitSound);
            if (!playerHealth.IsAlive)
            {
                SceneManager.LoadScene("GameOver");
            }
            Destroy(gameObject);
        }
    }
}
