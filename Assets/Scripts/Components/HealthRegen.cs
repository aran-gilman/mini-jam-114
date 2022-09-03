using UnityEngine;

public class HealthRegen : MonoBehaviour, IMoving
{
    public float initialSpeed;

    public float InitialSpeed { get => initialSpeed; }

    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.Change(1);
            }
            animator.SetTrigger("Explode");
        }
    }
}
