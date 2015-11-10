using UnityEngine;
using System.Collections;

public class Animation_SelfDestructOnEnd : MonoBehaviour
{
	public float animationLength = 1f;

	private IEnumerator KillOnAnimationEnd ()
	{
		yield return new WaitForSeconds (animationLength);
		Destroy (gameObject);
	}
	
	void Start ()
	{
		StartCoroutine (KillOnAnimationEnd ());
	}
}
