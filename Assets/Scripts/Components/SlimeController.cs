using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{
    public float initialSpeed;
    public Direction direction;

    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void Start()
    {
        rb.velocity = DirectionUtil.ToVector(direction) * initialSpeed;
    }
}
