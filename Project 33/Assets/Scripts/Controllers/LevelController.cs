using UnityEngine;

public class LevelController : MonoBehaviour
{
    [Header("Enviroment objects.")]
    public GameObject[] background;
    public GameObject[] scenery;
    public GameObject[] ground;

    [Header("Enviroment scrolling speeds.")]
    public int backgroundScrollingSpeed = 10;
    public int sceneryScrollingSpeed = 20;
    public int groundScrollingSpeed = 30;

    public float scrollingMultiplier = 1;

    Vector3 backgroundScrollingVelocity;
    Vector3 sceneryScrollingVelocity;
    Vector3 groundScrollingVelocity;

    public void Update()
    {
        foreach (GameObject go in background)
            go.transform.position -= backgroundScrollingVelocity * Time.deltaTime * scrollingMultiplier;
        foreach (GameObject go in scenery)
            go.transform.position -= sceneryScrollingVelocity * Time.deltaTime * scrollingMultiplier;
        foreach (GameObject go in ground)
            go.transform.position -= groundScrollingVelocity * Time.deltaTime * scrollingMultiplier;
    }

    void Start()
    {
        backgroundScrollingVelocity = new Vector3(backgroundScrollingSpeed, 0);
        sceneryScrollingVelocity = new Vector3(sceneryScrollingSpeed, 0);
        groundScrollingVelocity = new Vector3(groundScrollingSpeed, 0);
    }
}