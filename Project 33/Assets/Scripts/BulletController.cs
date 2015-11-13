using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
    public int bulletSpeed = 50;
    public int bulletDamage = 1;
    public GameObject hitAnimation;
    Vector3 bulletVelocity;

    void Start()
    {
        bulletVelocity = new Vector3(bulletSpeed, 0);
    }

    void Update () {
        transform.position += bulletVelocity * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        print(GetComponent<Collider2D>().name + " collided with " + coll.collider.name);
        if (coll.gameObject.tag != "Player")
        {
            if (coll.gameObject.tag == "Enemy")
                coll.gameObject.SendMessage("Damage", bulletDamage);

            Instantiate(hitAnimation, transform.position, transform.rotation);
            
            Destroy(gameObject);
        }
    }
}
