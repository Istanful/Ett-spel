using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    [Header("Level settings")]
    public string levelName;

    [Header("Player")]
    public GameObject player;

    [Header("UI Objects")]
    public GameObject UI;
    internal Text pointsText;

    [Header("Enviroment objects")]
    public GameObject[] background;
    public GameObject[] scenery;
    public GameObject[] ground;

    [Header("Enviroment scrolling speeds")]
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
        {
            if (go != null)
                go.transform.position -= groundScrollingVelocity * Time.deltaTime * scrollingMultiplier;
        }
    }

    void Start()
    {
        instance = this;

        UI = Instantiate(UI);
        pointsText = UI.transform.Find("HUD").Find("PointsText").GetComponent<Text>();

        player = (GameObject)Instantiate(player, player.transform.position, player.transform.rotation);

        backgroundScrollingVelocity = new Vector3(backgroundScrollingSpeed, 0);
        sceneryScrollingVelocity = new Vector3(sceneryScrollingSpeed, 0);
        groundScrollingVelocity = new Vector3(groundScrollingSpeed, 0);
    }
}