using UnityEngine;

public class CurveRenderer : MonoBehaviour
{
    public Color c1;
    public Color c2;
    public float physicsScale = 1;
    public int numSteps = 50;
    public float stepDistance = .5f;
    LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Mobile/Particles/Additive"));
        lineRenderer.SetColors(c1, c2);
        lineRenderer.SetWidth(0.1F, 0.1F);
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }
    void Update()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.z = transform.position.z;

        Vector3 start = transform.position;
        Vector3 end = mp;

        UpdateTrajectory(transform.position, -(start - end) - (Physics.gravity * physicsScale) / 2, (Physics.gravity * physicsScale), numSteps, stepDistance);
    }

    void UpdateTrajectory(Vector3 initialPosition, Vector3 initialVelocity, Vector3 gravity, int numSteps, float stepDistance)
    {
        float timeDelta = stepDistance / 5;

        lineRenderer.SetVertexCount(numSteps);
        Vector3 position = initialPosition;
        Vector3 velocity = initialVelocity;
        for (int i = 0; i < numSteps; ++i)
        {
            lineRenderer.SetPosition(i, position);
            position += velocity * timeDelta + 0.5f * gravity * timeDelta * timeDelta;
            velocity += gravity * timeDelta;
        }
    }
}