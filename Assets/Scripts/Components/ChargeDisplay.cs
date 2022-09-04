using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class ChargeDisplay : MonoBehaviour
{
    public GameObject chargePrefab;
    public PlayerInputWrapper playerInput;
    public RectTransform rectTransform;
    public float minAlpha = 0.25f;

    private void Update()
    {
        rectTransform.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Horizontal,
            chargePrefab.GetComponent<Image>().sprite.rect.width * playerInput.maxFireSpellCharges);

        if (transform.childCount > playerInput.maxFireSpellCharges)
        {
            for (int i = playerInput.maxFireSpellCharges; i < transform.childCount; i++)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
        else if (transform.childCount < playerInput.maxFireSpellCharges)
        {
            int diff = playerInput.maxFireSpellCharges - transform.childCount;
            for (int i = 0; i < diff; i++)
            {
                GameObject go = Instantiate(chargePrefab, transform);
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            Image img = transform.GetChild(i).GetComponent<Image>();
            float alpha = 1.0f;
            if (i > playerInput.currentFireSpellCharges)
            {
                alpha = minAlpha;
            }
            else if (i == playerInput.currentFireSpellCharges)
            {
                float percent = playerInput.currentChargeCooldown / playerInput.fireSpellChargeCooldown;
                alpha = 1 - (1 - minAlpha) * percent;
            }
            img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
        }
    }
}
