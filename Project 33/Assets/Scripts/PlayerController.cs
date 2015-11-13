using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class PlayerController : MonoBehaviour
{
	public GameObject bullet;
	public int weaponCooldown = 1000;
	private bool canShoot = true;

	void Update ()
	{
		if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && canShoot && (Time.timeScale != 0) && (Input.GetMouseButton (0) || Input.touchCount != 0)) {
            GameObject spawnedBullet = (GameObject)Instantiate (bullet, (transform.position + bullet.transform.position), transform.rotation);
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