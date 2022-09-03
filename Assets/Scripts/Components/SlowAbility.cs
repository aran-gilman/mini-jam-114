using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlowAbility : MonoBehaviour
{
    public float cooldownDuration;
    public float effectDuration;
    public float enemySpeedModifier = 0.5f;

    public UnityEvent onCooldownStart = new UnityEvent();
    public UnityEvent onCooldownEnd = new UnityEvent();

    public void Activate()
    {
        if (remainingCooldownTime > 0)
        {
            return;
        }
        remainingCooldownTime = cooldownDuration;
        remainingEffectTime = effectDuration;

        originalEnemyVector.Clear();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                originalEnemyVector.Add(rb, rb.velocity);
                rb.velocity *= enemySpeedModifier;
            }
        }

        onCooldownStart.Invoke();
    }

    public void Deactivate()
    {
        remainingEffectTime = 0.0f;

        if (originalEnemyVector == null)
        {
            return;
        }

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            if (originalEnemyVector.ContainsKey(rb))
            {
                rb.velocity = originalEnemyVector[rb];
            }
        }
    }

    private float remainingCooldownTime;
    private float remainingEffectTime;

    private Dictionary<Rigidbody2D, Vector2> originalEnemyVector = new Dictionary<Rigidbody2D, Vector2>();

    private void Update()
    {
        if (remainingCooldownTime > 0)
        {
            remainingCooldownTime -= Time.deltaTime;

            if (remainingCooldownTime <= 0)
            {
                onCooldownEnd.Invoke();
            }
        }

        if (remainingEffectTime > 0)
        {
            remainingEffectTime -= Time.deltaTime;
            if (remainingEffectTime <= 0)
            {
                Deactivate();
            }
        }
    }
}
