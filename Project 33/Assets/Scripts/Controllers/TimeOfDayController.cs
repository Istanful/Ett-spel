using UnityEngine;
using System.Collections;

public class TimeOfDayController : MonoBehaviour
{
    public bool stopAtPosition = false;
    public float stopOverPercent;

    public float rotationStep = 0.1f;
    public float rotationFrequency = 0.1f;
    Vector3 _rotationStep;

    public Light sunLight;

    public Color dayColor = Color.white;
    public Color nightColor = new Color(0.4f, 0, 0.6f);

    void Start()
    {
        _rotationStep = new Vector3(0, 0, rotationStep);
        InvokeRepeating("Animate", 0, rotationFrequency);
    }

    void Animate()
    {
        transform.eulerAngles += _rotationStep;
        foreach (Transform tra in transform)
        {
            tra.eulerAngles -= _rotationStep;
        }

        float percent = transform.eulerAngles.z / 360;

        if (stopAtPosition && (stopOverPercent <= (percent * 10)))
        {
            CancelInvoke();
        }
        else {
            if (percent < 0.5f)
            { //sun going up
                sunLight.color = Color.Lerp(nightColor, dayColor, percent * 2);
            }
            else
            { //sun going down
                sunLight.color = Color.Lerp(nightColor, dayColor, 1 - ((percent - 0.5f) * 2));
            }
        }
        
    }
}