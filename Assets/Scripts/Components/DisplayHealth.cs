using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class DisplayHealth : MonoBehaviour
{
    public Health healthToDisplay;

    public GameObject healthIndicatorSegmentPrefab;
    public Sprite fullSegmentSprite;
    public Sprite emptySegmentSprite;

    private void Update()
    {
        if (transform.childCount > healthToDisplay.maxHealth)
        {
            for (int i = healthToDisplay.maxHealth; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        else if (transform.childCount < healthToDisplay.maxHealth)
        {
            int diff = healthToDisplay.maxHealth - transform.childCount;
            for (int i = 0; i < diff; i++)
            {
                GameObject go = Instantiate(healthIndicatorSegmentPrefab, transform);
                go.GetComponent<Image>().sprite = fullSegmentSprite;
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            Image img = transform.GetChild(i).GetComponent<Image>();
            img.sprite = i < healthToDisplay.currentHealth ? fullSegmentSprite : emptySegmentSprite;
        }
    }
}
