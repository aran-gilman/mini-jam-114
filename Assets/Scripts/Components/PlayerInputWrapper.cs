using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputWrapper : MonoBehaviour
{
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upSprite;

    public GameObject fireSpellPrefab;
    public float projectileCooldown = 1.0f;

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
        if (currentProjectileCooldown > 0.0f)
        {
            return;
        }

        GameObject go = Instantiate(fireSpellPrefab);
        go.GetComponent<Projectile>().direction = direction;
        go.transform.position = transform.position;

        currentProjectileCooldown = projectileCooldown;
    }

    private Direction direction;
    private float currentProjectileCooldown;

    private void Start()
    {
        direction = Direction.Left;
        spriteRenderer.sprite = leftSprite;

        PlayerPrefs.SetInt("CurrentScore", 0);
    }

    private void Update()
    {
        if (currentProjectileCooldown > 0.0f)
        {
            currentProjectileCooldown -= Time.deltaTime;
        }
    }
}
