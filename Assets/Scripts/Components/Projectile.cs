using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Direction direction;

    public float speed;
    public Animator animator;
    public Rigidbody2D rb;

    public AudioClip fireSound;
    public AudioClip destructionSound;
    public PlaySfx sfxPlayer;

    public GameObject destructionFX;

    public void Destroy()
    {
        if (destructionFX != null)
        {
            GameObject go = Instantiate(destructionFX);
            go.transform.position = transform.position;
        }
        if (sfxPlayer != null)
        {
            sfxPlayer.Play(destructionSound);
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        animator.SetFloat("Direction", DirectionUtil.ToAnimationDirection(direction));
        rb.velocity = DirectionUtil.ToVector(direction) * speed;
    }
}
