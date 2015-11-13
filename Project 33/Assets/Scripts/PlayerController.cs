using UnityEngine;
using System.Collections;
using System.Threading;

public class PlayerController : MonoBehaviour
{
	public GameObject bullet;
	public int weaponCooldown = 1000;
	private bool canShoot = true;

	void Start ()
	{
	
	}

	void Update ()
	{
		if (canShoot && Input.GetMouseButtonDown (0)) {
            GameObject spawnedBullet = (GameObject)Instantiate (bullet, (transform.position + new Vector3 (21, 10.5f)), transform.rotation);
			spawnedBullet.transform.parent = transform;

			canShoot = false;
			new Timer (delegate {
				canShoot = true;
			}, null, weaponCooldown, 0);
		}
	}

	public void Kill ()
	{
		GameObject.Find ("GameController").SendMessage ("PlayerDied");
		Destroy (gameObject);
	}
}