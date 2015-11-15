using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{
    public int health = 2;
    public float knockback = 2;
    public float despawnTime = 0.5f;

    void Start () {
        Invoke("Despawn", despawnTime);
	}

    void Damage (int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            Despawn();
        }
    }

    void Despawn ()
    {
        GetComponent<Animator>().Play("Reversed");
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(gameObject, 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
            coll.gameObject.SendMessage("KnockedBack", knockback);
    }
}