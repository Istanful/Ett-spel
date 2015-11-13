using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject pointsText;
	public int points = 0;

	public void AddPoints (int newPoints)
	{
		points += newPoints;
        pointsText.GetComponent<Text>().text = "Points: " + points;
    }

    public void PlayerDied ()
	{

	}
}