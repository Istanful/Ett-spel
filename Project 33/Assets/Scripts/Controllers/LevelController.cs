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
    [SerializeField]
    public EnvironmentCategory[] environment;

    public float scrollingMultiplier = 1;

    public void Update()
    {
        foreach (EnvironmentCategory ec in environment)
            foreach (GameObject go in ec.objects)
                if (go != null)
                    go.transform.position -= ec.scrollingSpeed * Time.deltaTime * scrollingMultiplier;
    }

    void Start()
    {
        instance = this;

        UI = Instantiate(UI);
        pointsText = UI.transform.Find("HUD").Find("PointsText").GetComponent<Text>();

        player = (GameObject)Instantiate(player, player.transform.position, player.transform.rotation);

        Time.timeScale = 1;
    }

    [Serializable]
    public class EnvironmentCategory
    {
        public GameObject[] objects;
        public Vector3 scrollingSpeed;
    }
}