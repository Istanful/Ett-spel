using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static int points = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1;
    }

    public static void GoToMainMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    public static void RestartLevel()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }

    public static void AddPoints(int newPoints)
    {
        points += newPoints;
        LevelController.instance.pointsText.text = "Points: " + points;
    }

    public static void ResetPoints()
    {
        points = 0;
        LevelController.instance.pointsText.text = "Points: " + points;
    }

    public static void PlayerDied()
    {

    }

    public static void PlayerWon()
    {
        Camera.main.GetComponent<LevelCameraController>().followObject = null;
        LevelCameraController.instance.BeginBlur();
        LevelController.instance.scrollingMultiplier = 0;

        GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = Vector3.right * 25;
        EnemySpawner.instance.enabled = false;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length != 0)
            foreach (GameObject enemy in enemies)
                enemy.SendMessage("Die");

        Scoreboard.instance.ShowScoreboard(LevelController.instance.levelName, points);
        Debug.Log("Level Ended.");
    }
}