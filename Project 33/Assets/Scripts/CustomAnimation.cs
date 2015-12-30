using UnityEngine;

public class CustomAnimation : MonoBehaviour
{
    public PolygonCollider2D[] animationColliders;
    public Sprite[] animationFrames;
    public float secondsPerFrame = 1;
    public bool loop = true;
    public bool animateColliders = true;
    public bool randomizeStartingFrame = false;

    SpriteRenderer spriteRenderer;
    int maxFrameIndex = 0;
    int lastFrameIndex = 0;
    int currentFrameIndex = 0;

    void Start()
    {
        if (animationFrames.Length == 0)
            Error("There are no sprites attached to this script's \"Sprite\" array! (CustomAnimation will be disabled.)");
        if (animateColliders)
        {
            if (animationColliders.Length == 0)
                Error("There are no colliders added to this script's \"PolygonCollider2D\" array! (CustomAnimation will be disabled.)");
            else if (animationFrames.Length < animationColliders.Length)
                Error("There are more animation sprites than colliders! (CustomAnimation will be disabled.)");
            else if (animationFrames.Length > animationColliders.Length)
                Error("There are more colliders than animation sprites! (CustomAnimation will be disabled.)");
        }
        else
        {
            if ((spriteRenderer = gameObject.GetComponent<SpriteRenderer>()) == null)
                spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

            maxFrameIndex = animationFrames.Length - 1;

            if (animateColliders)
            {
                foreach (PolygonCollider2D collider in animationColliders)
                    collider.enabled = false;
                animationColliders[0].enabled = true;
            }

            if (randomizeStartingFrame)
                currentFrameIndex = Random.Range(0, maxFrameIndex);

            spriteRenderer.sprite = animationFrames[currentFrameIndex];
            InvokeRepeating("Animate", 0, secondsPerFrame);
        }
    }
    void Error(string message)
    {
        Debug.LogError("(ID: " + transform.GetInstanceID() + ") " + transform.name + ": " + message);
        enabled = false;
    }

    void Animate()
    {
        lastFrameIndex = currentFrameIndex;
        currentFrameIndex++;
        if (currentFrameIndex > maxFrameIndex)
            if (loop)
                currentFrameIndex = 0;
            else
            {
                CancelInvoke();
                spriteRenderer.sprite = null;
                return;
            }

        spriteRenderer.sprite = animationFrames[currentFrameIndex];

        if (animateColliders)
        {
            animationColliders[lastFrameIndex].enabled = false;
            animationColliders[currentFrameIndex].enabled = true;
        }
    }
}