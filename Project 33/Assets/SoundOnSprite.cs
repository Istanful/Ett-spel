using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class SoundOnSprite : MonoBehaviour
{
    [SerializeField]
    public TriggerSprite[] triggeringSprites;
    
    SpriteRenderer spriteRenderer;
    Sprite oldSprite;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        foreach (TriggerSprite ts in triggeringSprites)
        {
            ts.audioSource = gameObject.AddComponent<AudioSource>();
            ts.audioSource.clip = ts.audioClip;
        }
    }
    
    void Update()
    {
        if (spriteRenderer.sprite != oldSprite)
        {
            foreach (TriggerSprite ts in triggeringSprites)
                if (ts.triggerSprite == spriteRenderer.sprite)
                    ts.audioSource.PlayOneShot(ts.audioClip);
            
            oldSprite = spriteRenderer.sprite;
        }
    }

    [System.Serializable]
    public class TriggerSprite
    {
        public Sprite triggerSprite;
        public AudioClip audioClip;

        [HideInInspector]
        public AudioSource audioSource;

        [Range(0, 1)]
        public float volume = 1;
    }
}