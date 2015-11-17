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

    public void GoToMainMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void AddPoints(int newPoints)
	{
		points += newPoints;
        foreach (GameObject pointsText in GameObject.FindGameObjectsWithTag("PointTextUI"))
            pointsText.GetComponent<Text>().text = "Points: " + points;
    }

    public void ResetPoints()
	{
		points = 0;
        foreach (GameObject pointsText in GameObject.FindGameObjectsWithTag("PointTextUI"))
            pointsText.GetComponent<Text>().text = "Points: " + points;
    }

    public void PlayerDied()
	{

	}
}