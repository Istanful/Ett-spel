using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour
{
	public float lifetimeSeconds = 1f;

	void Start ()
	{
        Destroy(gameObject, lifetimeSeconds);
	}
}