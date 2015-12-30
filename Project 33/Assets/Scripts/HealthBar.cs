using UnityEngine;

public class HealthBar : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] healthBarStates;
    public float maxHealth;
    public float currentHealth {
        set
        {
            spriteRenderer.sprite = healthBarStates[Mathf.RoundToInt(value / maxHealth * healthBarStates.Length) - 1];
        }
    }

	void Start () {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = healthBarStates[healthBarStates.Length-1];
        spriteRenderer.sortingLayerName = "UI";
        currentHealth = maxHealth;
    }
}