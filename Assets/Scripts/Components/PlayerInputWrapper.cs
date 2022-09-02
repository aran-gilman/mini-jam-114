using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputWrapper : MonoBehaviour
{
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upSprite;

    public GameObject fireSpellPrefab;
    public Sprite fireLeftSprite;
    public Sprite fireRightSprite;
    public Sprite fireUpSprite;

    public SpriteRenderer spriteRenderer;

    public void OnMove(InputValue value)
    {
        Vector2 vectorValue = value.Get<Vector2>();
        if (vectorValue.x > 0)
        {
            spriteRenderer.sprite = rightSprite;
            direction = Direction.Right;
        }
        else if (vectorValue.x < 0)
        {
            spriteRenderer.sprite = leftSprite;
            direction = Direction.Left;
        }
        else if (vectorValue.y > 0)
        {
            spriteRenderer.sprite = upSprite;
            direction = Direction.Up;
        }
    }

    public void OnFire()
    {
        GameObject go = Instantiate(fireSpellPrefab);
        SpriteRenderer fireSpriteRenderer = go.GetComponent<SpriteRenderer>();
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        go.transform.position = transform.position;

        switch(direction)
        {
            case Direction.Left:
                fireSpriteRenderer.sprite = fireLeftSprite;
                rb.velocity = Vector2.left;
                break;

            case Direction.Right:
                fireSpriteRenderer.sprite = fireRightSprite;
                rb.velocity = Vector2.right;
                break;

            case Direction.Up:
                fireSpriteRenderer.sprite = fireUpSprite;
                rb.velocity = Vector2.up;
                break;
        }
    }

    private Direction direction;

    private void Start()
    {
        direction = Direction.Left;
        spriteRenderer.sprite = leftSprite;
    }
}
