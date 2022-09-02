using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Direction direction;

    public float speed;
    public Animator animator;
    public Rigidbody2D rb;

    private void Start()
    {
        animator.SetFloat("Direction", DirectionUtil.ToAnimationDirection(direction));
        rb.velocity = DirectionUtil.ToVector(direction) * speed;
    }
}
