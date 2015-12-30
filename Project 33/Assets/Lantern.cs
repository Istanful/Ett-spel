using UnityEngine;
using System.Collections;

public class Lantern : MonoBehaviour
{
    public Vector3 lightPosition;
    public Sprite highLight;
    public Sprite lowLight;

    public float lightRange = 120;
    public int flickerRatio;
    public float flickerRatioHighScale = 1f;
    public float flickerRatioLowScale = 3f;
    public float highLightStrength = 1;
    public float lowLightStrength = 0.8f;
    public bool isHighLightStrength = true;

    Light lanternLight;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        if ((spriteRenderer = gameObject.GetComponent<SpriteRenderer>()) == null)
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        GameObject lanternLightObject = new GameObject("Light");
        lanternLightObject.transform.parent = transform;
        lanternLightObject.transform.localPosition = lightPosition;
        lanternLight = lanternLightObject.AddComponent<Light>();


        lanternLight.range = lightRange;
        lanternLight.intensity = highLightStrength;

        spriteRenderer.sprite = highLight;

        InvokeRepeating("Animate", 0, 0.1f);
    }

    void Animate()
    {
        if (Random.Range(0, (flickerRatio * ((isHighLightStrength) ? flickerRatioHighScale : flickerRatioLowScale))) < 1)
        {
            isHighLightStrength = !isHighLightStrength;
            spriteRenderer.sprite = (isHighLightStrength) ? highLight : lowLight;
            lanternLight.intensity = (isHighLightStrength) ? highLightStrength : lowLightStrength;
        }
    }
}
