using UnityEngine;
using System.Collections;

public class PointAtPointer : MonoBehaviour
{
    public Vector3 offset;

    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position + offset);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(Mathf.Clamp(angle, -45, 40), Vector3.forward);
    }
}