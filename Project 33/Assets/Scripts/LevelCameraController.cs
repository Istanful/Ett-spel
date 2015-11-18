using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class LevelCameraController : MonoBehaviour
{
    BlurOptimized blur;

    [Header("Follow object")]
    public GameObject followObject;
    public float xOffset;
    public float yOffset;

    [Header("Blur")]
    public float blurFadeDuration;
    public float shiftBlurSize;
    public float maxBlurSize;
    public int maxBlurIterations;

    void Update()
    {
        Camera.main.orthographicSize = (42 - 1) / Camera.main.aspect * 2;
        
        if (followObject != null)
            transform.position = new Vector3(followObject.transform.position.x + xOffset, followObject.transform.position.y + yOffset, transform.position.z);
    }

    
    public void BeginBlur()
    {
        Debug.Log("Begun fading blur");
        blur = GetComponent<BlurOptimized>();
        blur.enabled = true;
        InvokeRepeating("BlurFade", 0, 0.01f);
    }

    void BlurFade()
    {
        if (blur.blurSize < shiftBlurSize || (blur.blurSize < maxBlurSize && blur.blurIterations == maxBlurIterations))
        {
            blur.blurSize += maxBlurSize / (blurFadeDuration * 100);
        }
        else if (blur.blurSize >= shiftBlurSize && blur.blurIterations < maxBlurIterations)
        {
            blur.blurIterations += 1;
            blur.blurSize = 0;
        }
        else
        {
            Debug.Log("Finished fading blur");
            CancelInvoke("BlurFade");
        }
    }
}