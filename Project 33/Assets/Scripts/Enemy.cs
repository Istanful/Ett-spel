using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject deathAnimationPrefab;
	public float movementSpeed = 45;
    public int health = 2;
    public int pointsWorth = 1;

    TextMesh healthText;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        healthText = GetComponentInChildren<TextMesh>();
        healthText.text = "Health: " + health;
        rb.velocity = Vector2.left * movementSpeed;
    }

	void FixedUpdate ()
	{
        if (rb.velocity.magnitude < movementSpeed)
            rb.AddForce(Vector2.left, ForceMode2D.Impulse);
        else if (rb.velocity.magnitude > movementSpeed)
        {
            Debug.Log("Movement speed exceeds maximum: " + rb.velocity.magnitude);
            rb.velocity = rb.velocity.normalized * movementSpeed;
        }
    }

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
			coll.gameObject.SendMessage ("Die");
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

    void KnockedBack(float strength)
    {
        Debug.Log(transform.name + " got knocked back.");
        GetComponent<Rigidbody2D>().AddForce(Vector3.right * strength, ForceMode2D.Impulse);
    }
}