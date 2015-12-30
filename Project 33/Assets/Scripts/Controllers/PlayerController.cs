using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject deathAnimationPrefab;

    public Abilities _abilities;
    public static Abilities abilities;

    public ArmAnimator armAnimator;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        armAnimator.arm = gameObject.transform.Find("Arm");
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("Animate", 0, armAnimator.secondsPerFrame);

        InvokeRepeating("LowerCooldowns", 0, 0.01f);
        abilities = _abilities;
    }

    void Update()
    {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && (Time.timeScale != 0))
            if (Input.touchCount > 0 || Input.GetMouseButton(0))
                UseAbility(abilities.Basic);

        switch (SwipeController.swipeDirection)
        {
            case Swipe.FrontUp:
                UseAbility(abilities.FrontUp);
                break;
            case Swipe.Front:
                UseAbility(abilities.Front);
                break;
            case Swipe.FrontDown:
                UseAbility(abilities.FrontDown);
                break;

            case Swipe.BackUp:
                UseAbility(abilities.BackUp);
                break;
            case Swipe.BackDown:
                UseAbility(abilities.BackDown);
                break;
        }
    }
    public void Die()
    {
        GameController.PlayerDied();

        Instantiate(deathAnimationPrefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    void LowerCooldowns()
    {
        if (abilities.Basic.currentCooldown > 0)
            abilities.Basic.currentCooldown -= 1;

        if (abilities.FrontUp.currentCooldown > 0)
            abilities.FrontUp.currentCooldown -= 1;
        if (abilities.Front.currentCooldown > 0)
            abilities.Front.currentCooldown -= 1;
        if (abilities.FrontDown.currentCooldown > 0)
            abilities.FrontDown.currentCooldown -= 1;

        if (abilities.BackUp.currentCooldown > 0)
            abilities.BackUp.currentCooldown -= 1;
        if (abilities.BackDown.currentCooldown > 0)
            abilities.BackDown.currentCooldown -= 1;
    }

    void UseAbility(Ability usedAbility)
    {
        if (usedAbility.currentCooldown == 0)
        {
            // Disable the bullet's "AddRelativeForce" and uncomment the code below to behold the worst attempt at bullet physics in a long time.
            // You (probably) also need to set the bullet's mass and gravity scale to 1.
            // --------------------------------------------
            // Quiz time: Can you guess what happens?
            // Spoiler: Bullet physics becomes REALLY (and I mean it, REALLY) weird. (Bullets become slow, can be shot in any direction and weighs about as much as a 10x10cm brick of concrete.)
            // --------------------------------------------

            /*
            GameObject aimAssist = GameObject.Find("AimAssist");
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mp.z = aimAssist.transform.position.z;
            Vector3 start = aimAssist.transform.position;
            Vector3 end = mp;
            GameObject spawnedBullet = (GameObject)Instantiate(usedAbility.spawnedObject, (aimAssist.transform.position + usedAbility.spawnedObject.transform.position), transform.rotation);
            Collider2D playerEdgeCollider = gameObject.GetComponent<Collider2D>();

            foreach (Collider2D collider in spawnedBullet.GetComponents<Collider2D>())
                Physics2D.IgnoreCollision(collider, playerEdgeCollider);

            spawnedBullet.GetComponent<Rigidbody2D>().velocity = -(start - end) - (Physics.gravity * aimAssist.GetComponent<CurveRenderer>().physicsScale) / 2;
            */

            Instantiate(usedAbility.spawnedObject, (transform.position + usedAbility.spawnedObject.transform.position), transform.rotation);
            usedAbility.currentCooldown = usedAbility.maxCooldown;
            Debug.Log("Used ability: " + usedAbility.spawnedObject.name);
        }
    }

    void Animate()
    {
        spriteRenderer.sprite = armAnimator.playerAnimationFrames[armAnimator.nextFrame];
    }

    [System.Serializable]
    public class Ability
    {
        public GameObject spawnedObject;
        public int maxCooldown;

        public int currentCooldown = 0;
    }
    [System.Serializable]
    public class Abilities
    {
        public Ability Basic;

        public Ability FrontUp;
        public Ability Front;
        public Ability FrontDown;

        public Ability BackUp;
        public Ability BackDown;
    }

    [System.Serializable]
    public class ArmAnimator
    {
        int _currentFrame = 0;
        public Transform arm;

        public float secondsPerFrame;
        public Sprite[] playerAnimationFrames;
        public Vector2[] armPositions;

        internal int nextFrame
        {
            get
            {
                _currentFrame++;
                if (_currentFrame > playerAnimationFrames.Length - 1)
                    _currentFrame = 0;

                arm.localPosition = armPositions[_currentFrame];

                return _currentFrame;
            }
        }
    }
}