using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    public Abilities _abilities;
    public static Abilities abilities;

    void OnBecameInvisible()
    {
        Camera.main.GetComponent<LevelCameraController>().BeginBlur();
    }

    void Start ()
    {
        InvokeRepeating("LowerCooldowns", 0, 0.01f);
        abilities = _abilities;
    }

    void Update ()
	{
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject () && (Time.timeScale != 0))
        {
            if (Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                UseAbility(abilities.Basic);
            }
		}

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

    public void Die ()
    {
        GameObject.Find("GameController").SendMessage("PlayerDied");
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
            Instantiate(usedAbility.spawnedObject, (transform.position + usedAbility.spawnedObject.transform.position), transform.rotation);
            usedAbility.currentCooldown = usedAbility.maxCooldown;
            Debug.Log("Used ability: " + usedAbility.spawnedObject.name);
        }
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
}