using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public int bulletSpeed = 50;
    public float bulletDamage = 1;
    public GameObject hitAnimation;
    Vector3 bulletVelocity;

    void Start()
    {
        bulletVelocity = new Vector3(bulletSpeed, 0);
    }

    void Update () {
        transform.position += bulletVelocity * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if ((coll.gameObject.tag != "Player") && (coll.gameObject.tag != "Ability") && (coll.gameObject.tag != "Companion"))
        {
            if (coll.gameObject.tag == "Enemy")
                coll.gameObject.SendMessage("Damage", bulletDamage);

            Instantiate(hitAnimation, transform.position, transform.rotation);
            
            Destroy(gameObject);
        }
    }
}
