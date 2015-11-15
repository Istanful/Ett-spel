using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{
    public int health = 2;
    public float movementSpeed = 1;
    public float despawnTime = 0.125f;

    void Start () {
        Invoke("Despawn", despawnTime);
    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * movementSpeed;
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
        Destroy(gameObject, 0.5f);
    }
}