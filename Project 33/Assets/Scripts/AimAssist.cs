using UnityEngine;
using System.Collections;

public class AimAssist : MonoBehaviour
{
    public Vector3 offset;
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Mobile/Particles/Additive"));
        lineRenderer.SetColors(c1, c2);
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.SetVertexCount(2);
    }

    void Update()
    {

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position + offset);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Mathf.Clamp(angle, -45, 40);

        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.z = 0;

        if (Mathf.Abs(angle) < 45)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, mp);
        }
        else
            lineRenderer.enabled = false;
    }
}