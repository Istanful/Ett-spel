using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static bool matchEnded = false;
    public static int points = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1;
    }

    public static void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public static void Reset()
    {
        points = 0;
        LevelController.instance.pointsText.text = "Points: " + points;

        matchEnded = false;
        Time.timeScale = 1;
    }

    public static void RestartLevel()
    {
        Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        matchEnded = true;
    }

    public static void PlayerWon()
    {
        matchEnded = true;
        Camera.main.GetComponent<LevelCameraController>().followObject = null;
        LevelCameraController.instance.BeginBlur();
        LevelController.instance.scrollingMultiplier = 0;

        EnemySpawner.instance.enabled = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length != 0)
            foreach (GameObject enemy in enemies)
                enemy.SendMessage("Die");

        GameObject.Find("Player(Clone)").GetComponent<Rigidbody2D>().velocity = Vector3.right * 25;
        Scoreboard.instance.ShowScoreboard(LevelController.instance.levelName, points);
        Debug.Log("Level Ended.");
    }
}