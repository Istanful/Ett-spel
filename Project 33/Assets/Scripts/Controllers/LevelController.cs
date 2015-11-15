using UnityEngine;

public class LevelController : MonoBehaviour {

    [Header("Enviroment objects.")]
    public GameObject background;
    public GameObject scenery;
    public GameObject ground;

    [Header("Enviroment scrolling speeds.")]
    public int backgroundScrollingSpeed = 10;
    public int sceneryScrollingSpeed = 20;
    public int groundScrollingSpeed = 30;

    Vector3 backgroundScrollingVelocity;
    Vector3 sceneryScrollingVelocity;
    Vector3 groundScrollingVelocity;

    public void Update()
    {
        background.transform.position -= backgroundScrollingVelocity * Time.deltaTime;
        scenery.transform.position -= sceneryScrollingVelocity * Time.deltaTime;
        ground.transform.position -= groundScrollingVelocity * Time.deltaTime;
    }

    void Start ()
    {
        backgroundScrollingVelocity = new Vector3(backgroundScrollingSpeed, 0);
        sceneryScrollingVelocity = new Vector3(sceneryScrollingSpeed, 0);
        groundScrollingVelocity = new Vector3(groundScrollingSpeed, 0);
    }
}