using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour
{
    public int health = 2;

    void Start () {
        Invoke("Despawn", 0.5f);
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
        Destroy(gameObject, 1);
    }
}
