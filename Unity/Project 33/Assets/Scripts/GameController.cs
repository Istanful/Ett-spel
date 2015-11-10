using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private int
		points = 0;

	public void AddPoints (int newPoints)
	{
		points += newPoints;
	}

	public void PlayerDied ()
	{

	}
}