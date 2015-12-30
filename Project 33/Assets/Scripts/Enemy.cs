using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject deathAnimationPrefab;
	public float movementSpeed = 45;
    public int pointsWorth = 1;

    public Sprite[] healthBarStates;
    public float maxHealth = 2;
    public float healthBarYOffset = 2;
    float currentHealth;
    HealthBar healthBar;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        PolygonCollider2D polygonCollider = GetComponent<PolygonCollider2D>();

        float minX = float.MaxValue;
        float maxX = float.MinValue;
        float maxY = float.MinValue;

        foreach (Vector2 point in polygonCollider.points)
        {
            if (point.x < minX) minX = point.x;
            if (point.x > maxX) maxX = point.x;
            if (point.y > maxY) maxY = point.y;
        }

        GameObject healthBarObject = new GameObject();
        healthBarObject.transform.parent = transform;
        healthBar = healthBarObject.AddComponent<HealthBar>();
        healthBar.transform.localPosition = new Vector2((maxX - minX)/2, maxY + healthBarYOffset);
        healthBar.healthBarStates = healthBarStates;
        healthBar.maxHealth = maxHealth;

        currentHealth = maxHealth;

    }

	void FixedUpdate ()
    {
        if (rb.velocity.magnitude < movementSpeed)
            rb.AddForce(Vector2.left * (rb.mass/2), ForceMode2D.Impulse);
        else if (rb.velocity.magnitude > movementSpeed)
        {
            rb.velocity = rb.velocity.normalized * movementSpeed;
        }
    }

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
			coll.gameObject.SendMessage ("Die");
	}

    void Damage(float damageTaken)
    {
        currentHealth -= damageTaken;

        if (currentHealth <= 0)
            Die();
        else
            healthBar.currentHealth = currentHealth;
    }

    void Die()
    {
        GameController.AddPoints(pointsWorth); 

        Instantiate(deathAnimationPrefab, transform.position + (Vector3.left * 7), transform.rotation);
        Destroy(gameObject);
    }
}