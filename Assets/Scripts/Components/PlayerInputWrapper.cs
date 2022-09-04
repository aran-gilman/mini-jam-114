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

    public int maxFireSpellCharges = 3;
    public int currentFireSpellCharges = 3;
    public float fireSpellChargeCooldown = 0.5f;
    public float currentChargeCooldown;

    public SpriteRenderer spriteRenderer;
    public PlaySfx sfxPlayer;

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
        if (currentProjectileCooldown > 0.0f || currentFireSpellCharges <= 0)
        {
            return;
        }

        GameObject go = Instantiate(fireSpellPrefab);
        go.transform.position = transform.position;

        Projectile projectile = go.GetComponent<Projectile>();
        projectile.direction = direction;
        // We play the sfx here instead of inside Projectile because the projectile's own SfxPlayer may not be initialized yet
        sfxPlayer.Play(projectile.fireSound);

        currentProjectileCooldown = projectileCooldown;
        currentFireSpellCharges--;
    }

    public void OnSlow()
    {
        SlowAbility ability = GetComponent<SlowAbility>();
        ability.Activate();
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

        if (currentChargeCooldown > 0.0f)
        {
            currentChargeCooldown -= Time.deltaTime;
            if (currentChargeCooldown < 0.0f && currentFireSpellCharges < maxFireSpellCharges)
            {
                currentFireSpellCharges++;
            }
        }
        else if (currentFireSpellCharges != maxFireSpellCharges)
        {
            currentChargeCooldown = fireSpellChargeCooldown;
        }
    }
}
