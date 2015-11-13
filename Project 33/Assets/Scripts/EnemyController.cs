using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject deathAnimationPrefab;
	public float movementSpeed = 0.3f;
    public int health = 2;
    public int pointsWorth = 1;

    TextMesh healthText;

    void Start()
    {
        healthText = GetComponentInChildren<TextMesh>();
        healthText.text = "Health: " + health;
    }

	void FixedUpdate ()
	{
		transform.Translate (new Vector3 (-movementSpeed - 0.6f, 0, 0));
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		print ("Collided with: " + coll.collider.name);
		if (coll.gameObject.tag == "Player")
			coll.gameObject.SendMessage ("Kill");
	}

    void Damage(int damageTaken)
    {
        health -= damageTaken;
        healthText.text = "Health: " + health;
        if (health <= 0)
        {
            GameObject.Find("GameController").SendMessage("AddPoints", pointsWorth);

            Instantiate(deathAnimationPrefab, transform.position + (Vector3.left * 7), transform.rotation);
            Destroy(gameObject);
        }  
    }
}