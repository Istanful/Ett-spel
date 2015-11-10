﻿using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyController : MonoBehaviour
{
	public float movementSpeed = -0.5f;

	void FixedUpdate ()
	{
		transform.Translate (new Vector3 (movementSpeed, 0, 0));
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		print ("Collided with: " + coll);
		if (coll.gameObject.tag == "Player")
			coll.gameObject.SendMessage ("Kill");

		if (coll.gameObject.tag == "EnemyKiller") {
			GameObject.Find ("GameController").SendMessage ("AddPoints", 1);
			Destroy (gameObject);
		}
	}
}